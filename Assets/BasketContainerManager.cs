using UnityEngine;
using System.Collections;

public class BasketContainerManager : MonoBehaviour
{
    public GameObject coinTrackerGameObject; // Drag the GameObject with the CoinTracker script attached here in the inspector
    private CoinTracker coinTracker;

    public GameObject prefabToInstantiate;
    private bool isInstantiated = false;

    private void Start()
    {
        coinTracker = coinTrackerGameObject.GetComponent<CoinTracker>();
        CheckChildObject();
    }

    private void CheckChildObject()
    {
        foreach (Transform child in transform)
        {
            Collider collider = child.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = coinTracker.GetCoinCount() >= 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TongueTip") && coinTracker.GetCoinCount() < 1)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
                StartCoroutine(DisableMeshRenderer(meshRenderer, 1f));
            }
        }
    }

    private IEnumerator DisableMeshRenderer(MeshRenderer meshRenderer, float delay)
    {
        yield return new WaitForSeconds(delay);
        meshRenderer.enabled = false;
    }

    private void OnTransformChildrenChanged()
    {
        if (transform.childCount == 0 && prefabToInstantiate != null && !isInstantiated)
        {
            StartCoroutine(InstantiateAfterDelay());
        }

        // Check the coin count and disable/enable the Collider accordingly
        CheckChildObject();
    }

    private IEnumerator InstantiateAfterDelay()
    {

        // Remove a coin from the container
        coinTracker.RemoveCoin(coinTracker.coinsInside[0]);

        isInstantiated = true;
        yield return new WaitForSeconds(2f);
        Vector3 position = transform.TransformPoint(new Vector3(0.134000003f, -0.0560000017f, -0.277999997f));
        Quaternion rotation = Quaternion.Euler(new Vector3(1f, 1f, 1f));
        Instantiate(prefabToInstantiate, position, rotation, transform);
        isInstantiated = false;
        // Check if there is at least one coin in the container


    }

        private void Update()
    {
        // Update the collider state every time the coin count changes
        CheckChildObject();
    }
}
