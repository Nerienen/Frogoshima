using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRigidbodyKinematic : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position != lastPosition)
        {
            rb.isKinematic = false;
        }
        lastPosition = transform.position;
    }
}
