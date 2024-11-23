using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCorkInversed : MonoBehaviour
{
  
    public float rotationAngle = 90f;
    public float rotationTime = 1f;
    public Transform pivot;

    private bool corkIsOpen = false;
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float rotationSpeed;

    void Start()
    {
        initialRotation = transform.localRotation;
        rotationSpeed = rotationAngle / rotationTime;
        targetRotation = initialRotation * Quaternion.Euler(0f, rotationAngle, 0f); // Change rotation angle sign
    }

    void Update()
    {
    }

    private IEnumerator RotateCork()
    {
        corkIsOpen = !corkIsOpen;
        Quaternion currentRotation = transform.localRotation;
        targetRotation = corkIsOpen ? initialRotation * Quaternion.Euler(0f, rotationAngle, 0f) : initialRotation; // Change rotation angle sign

        while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.01f)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.localRotation = targetRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TongueTip"))
        {
            StartCoroutine(RotateCork());
        }
    }
}


