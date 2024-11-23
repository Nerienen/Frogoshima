using UnityEngine;

public class Puker : MonoBehaviour
{
    public float impulseForce = 5.0f; // amount of force to apply to each child object

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (Transform child in transform)
            {
                child.SetParent(null);
                child.gameObject.SetActive(true);
             /*   Rigidbody childRigidbody = child.GetComponent<Rigidbody>();
                if (childRigidbody != null)
                {
                    childRigidbody.AddForce(transform.forward * impulseForce, ForceMode.Impulse);
                } */
            }
        }
    }
}
