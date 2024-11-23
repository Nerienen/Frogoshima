using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceInstantiator : MonoBehaviour
{
    public GameObject slice1;
    public GameObject slice2;
    public Vector3 spawnPosition1;
    public Vector3 spawnPosition2;
    public Vector3 slice1RotationEuler;
    public Vector3 slice2RotationEuler;
    private bool isSlicing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife") && !isSlicing)
        {
           // Debug.Log("Collided with le knife");

            KnifeRotator knifeRotator = other.transform.parent.parent.GetComponent<KnifeRotator>();

            if (knifeRotator != null && knifeRotator.IsRotating)
            {
               // Debug.Log("Instantiate");

                Vector3 finalPosition1 = transform.position + spawnPosition1;
                Vector3 finalPosition2 = transform.position + spawnPosition2;
                Quaternion slice1Rotation = Quaternion.Euler(slice1RotationEuler);
                Quaternion slice2Rotation = Quaternion.Euler(slice2RotationEuler);
                Instantiate(slice1, finalPosition1, slice1Rotation);
                Instantiate(slice2, finalPosition2, slice2Rotation);

                isSlicing = true;

                StartCoroutine(ResetSlicing());
            }
        }
    }

    private IEnumerator ResetSlicing()
    {
        yield return new WaitForSeconds(0.1f);

        isSlicing = false;
        gameObject.SetActive(false);
    }
}
