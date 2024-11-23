using UnityEngine;
using System.Collections;

public class TongueTipController : MonoBehaviour
{
    public Transform mouthTransform; // assign in inspector

    private void OnTriggerEnter(Collider other)
    {
        Pickupable pickupable = other.gameObject.GetComponent<Pickupable>();
        if (pickupable != null)
        {
            Vector3 mouthPosition = mouthTransform.position;
            Quaternion mouthRotation = mouthTransform.rotation;

            pickupable.transform.SetParent(mouthTransform);
            pickupable.transform.position = mouthPosition;
            pickupable.transform.rotation = mouthRotation;

            StartCoroutine(SetObjectInactive(pickupable.gameObject));
        }
    }

    private IEnumerator SetObjectInactive(GameObject obj)
    {
        yield return new WaitForSeconds(0.01f);
        obj.SetActive(false);
    }
}

