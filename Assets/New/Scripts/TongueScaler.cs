using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueScaler : MonoBehaviour
{
    public float fastClickTime = 0.5f;
    public float scaleTime = 1.5f;
    public float maxScale = 1f;
    public float minScale = 0.01f;
    public float currentScale = 0.01f;

    private bool isScaling = false;
    private bool isFastClick = false;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFastClick = true;
            StartCoroutine(ScaleTongue());
        }
        else if (Input.GetMouseButtonUp(0) && isScaling)
        {
            isFastClick = false;
            StopAllCoroutines();
            StartCoroutine(ReverseScaleTongue());
        }
    }

    IEnumerator ScaleTongue()
    {
        isScaling = true;
        timer = 0f;

        while (timer <= fastClickTime)
        {
            timer += Time.deltaTime;
            currentScale = Mathf.Lerp(minScale, maxScale, timer / fastClickTime);
            transform.localScale = new Vector3(currentScale, transform.localScale.y, transform.localScale.z);
            yield return null;
        }

        while (isFastClick && timer <= scaleTime)
        {
            timer += Time.deltaTime;
            currentScale = Mathf.Lerp(minScale, maxScale, timer / scaleTime);
            transform.localScale = new Vector3(currentScale, transform.localScale.y, transform.localScale.z);
            yield return null;
        }

        isScaling = false;
    }

    IEnumerator ReverseScaleTongue()
    {
        timer = 0f;

        while (timer <= scaleTime)
        {
            timer += Time.deltaTime;
            currentScale = Mathf.Lerp(maxScale, minScale, timer / scaleTime);
            transform.localScale = new Vector3(currentScale, transform.localScale.y, transform.localScale.z);
            yield return null;
        }
    }
}
