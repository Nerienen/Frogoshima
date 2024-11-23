using UnityEngine;

public class ScaleDownOnTrigger : MonoBehaviour
{
    public LayerMask compareLayer;
    public float lerpSpeed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if ((compareLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            // The colliding object is on the compareLayer, scale it down
            Vector3 targetScale = other.transform.localScale / 5f;
            other.transform.localScale = Vector3.Lerp(other.transform.localScale, targetScale, Time.deltaTime * lerpSpeed);
        }
    }
}
