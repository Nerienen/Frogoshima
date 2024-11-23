using UnityEngine;
using System.Collections;

public class OpenCorkBallSpawnerAlchemy : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float rotationTime = 1f;
    public Transform pivot;

    public bool theCorkIsOpen = false;
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float rotationSpeed;

    void Start()
    {
        initialRotation = transform.localRotation;
        rotationSpeed = rotationAngle / rotationTime;
        targetRotation = initialRotation * Quaternion.Euler(0f, -rotationAngle, 0f);
    }

   

    private IEnumerator RotateCork()
    {
        theCorkIsOpen = !theCorkIsOpen;
        Quaternion currentRotation = transform.localRotation;
        targetRotation = theCorkIsOpen ? initialRotation * Quaternion.Euler(0f, -rotationAngle, 0f) : initialRotation;

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
