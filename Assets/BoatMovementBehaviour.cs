using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementBehaviour : MonoBehaviour
{
    public float speed = 1f; // adjust the speed of the movement here
    public float impulseForce = 10f; // adjust the force of the impulse here
    public float impulseInterval = 0.5f; // adjust the interval between impulses here

    private Rigidbody rb;
    private float timeSinceLastImpulse = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        timeSinceLastImpulse += Time.fixedDeltaTime;
        if (timeSinceLastImpulse >= impulseInterval)
        {
            Vector3 localLeft = transform.TransformDirection(Vector3.left);
            rb.AddForce(localLeft * impulseForce, ForceMode.Impulse);
            timeSinceLastImpulse = 0f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<CharacterController>()) 
        { other.transform.root.parent = this.transform.root; }
    } 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<CharacterController>())
        { other.transform.root.parent = null; }
    } 
}
