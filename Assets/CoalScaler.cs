using UnityEngine;

public class CoalScaler : MonoBehaviour
{
    public float scaleSpeed = 0.08f;
    public float deactivateScaleThreshold = 3f;
    public GameObject coalPrefab;
    public Vector3 startingScale = new Vector3(20, 20, 20);

    private bool isScaling = true;
    private float timeSinceLastCheck = 0f;
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ingredient"))
        {
            // Set the other object to inactive
            collision.gameObject.SetActive(false);

            // Instantiate the explosion prefab at the other object's position
            GameObject coalInstance = Instantiate(coalPrefab, collision.transform.position, Quaternion.identity);
            coalInstance.transform.localScale = startingScale;
        }
    }

    private void Update()
    {
        // Decrease the scale of the object using lerp
        if (isScaling)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            particleSystem.Stop();
        }

        // If the scale goes below a certain threshold, set the object to inactive
        if (transform.localScale.magnitude < deactivateScaleThreshold)
        {
            gameObject.SetActive(false);
        }

        // Check if object is still inside the scaling stopper trigger
        timeSinceLastCheck += Time.deltaTime;
        if (timeSinceLastCheck >= 1.5f)
        {
            timeSinceLastCheck = 0f;
            if (!isScaling && !gameObject.GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("ScalingStopper").GetComponent<Collider>().bounds))
            {
                isScaling = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScalingStopper"))
        {
            isScaling = false;
        }
    }
}
