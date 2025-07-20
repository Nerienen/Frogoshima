using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ScaleOnPlayerCollision : MonoBehaviour
{
    public float scaleFactor = 0.7f;          // Scale down factor (50%)
    public float scaleDownDuration = 0.1f;    // Time to scale down (0.5 sec)
        
    private Vector3 originalScale;
    private Coroutine scaleRoutine;

    private void Start()
    {
        originalScale = transform.localScale;

    }

    private float scaleBackDuration = 300f;  // Time to scale back up 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (scaleRoutine != null)
                StopCoroutine(scaleRoutine);

            // Start the coroutine to scale down then scale back up
            scaleRoutine = StartCoroutine(ScaleDownThenUp());
        }
    }

    private System.Collections.IEnumerator ScaleDownThenUp()
    {
        // Scale down over scaleDownDuration
        yield return ScaleTo(originalScale * scaleFactor, scaleDownDuration);
        // Then scale back up over scaleBackDuration
        yield return ScaleTo(originalScale, scaleBackDuration);
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}