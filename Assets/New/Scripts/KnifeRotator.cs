using System.Collections;
using UnityEngine;

public class KnifeRotator : MonoBehaviour
{
    public float rotationTime = 0.2f; // time it takes to rotate object
    public float rotationAmount = 70f; // amount to rotate object on X axis
    private bool isRotating = false; // flag to indicate if object is currently rotating


    private Quaternion initialRotation; // initial rotation of the object

    public bool IsRotating
    {
        get { return isRotating; }
    }


    private void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1) && !isRotating)
        {
            // Start rotating object
            StartCoroutine(RotateObject());
        }
    }

    private IEnumerator RotateObject()
    {
        isRotating = true;

        // Rotate object on X axis
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(rotationAmount, 0, 0) * startRotation;
        float t = 0;

        while (t < rotationTime / 2)
        {
            t += Time.deltaTime;
            float fraction = t / (rotationTime / 2);

            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, fraction);

            yield return null;
        }

        // Rotate object back to initial rotation
        startRotation = transform.localRotation;
        endRotation = initialRotation;
        t = 0;

        while (t < rotationTime / 2)
        {
            t += Time.deltaTime;
            float fraction = t / (rotationTime / 2);

            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, fraction);

            yield return null;
        }

        // Set the rotation to the initial rotation to ensure it ends up at the same position and rotation
        transform.localRotation = initialRotation;

        isRotating = false;
    }
}