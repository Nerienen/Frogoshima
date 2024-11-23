using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionIntensityController : MonoBehaviour
{
    public Color enterEmissionColor = Color.blue;
    public Color enterBaseColor = Color.blue;
    public float enterTransitionTime = 1f;

    public Color exitEmissionColor = Color.black;
    public Color exitBaseColor = Color.black;
    public float exitTransitionTime = 4f;

    private Color currentEmissionColor;
    private Color currentBaseColor;
    private Color targetEmissionColor;
    private Color targetBaseColor;
    private float emissionVelocity;
    private float baseVelocity;

    private Material material;

    private bool reachedTargetColor = false;

    public GameObject coinTrackerGameObject; // Drag the GameObject with the CoinTracker script attached here in the inspector
    private CoinTracker coinTracker;

   

    
    private void Start()
    {
        coinTracker = coinTrackerGameObject.GetComponent<CoinTracker>();
        // Get the renderer and material for this object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            currentEmissionColor = material.GetColor("_EmissionColor");
            currentBaseColor = material.GetColor("_BaseColor");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TongueTip") && coinTracker.GetCoinCount() < 1)
        { 
        targetEmissionColor = enterEmissionColor;
        targetBaseColor = enterBaseColor;
        reachedTargetColor = false;
    }
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            reachedTargetColor = false;
        
    }

    private void Update()
    {
        if (material != null)
        {
            if (!reachedTargetColor)
            {
                // Update emission color
                currentEmissionColor = Color.Lerp(currentEmissionColor, targetEmissionColor, Time.deltaTime / enterTransitionTime);
                material.SetColor("_EmissionColor", currentEmissionColor);

                // Update base color
                currentBaseColor = Color.Lerp(currentBaseColor, targetBaseColor, Time.deltaTime / enterTransitionTime);
                material.SetColor("_BaseColor", currentBaseColor);

                // Check if the target colors have been reached
                if (currentEmissionColor == targetEmissionColor && currentBaseColor == targetBaseColor)
                {
                    reachedTargetColor = true;
                }
            }
            else
            {
                // Transition to exit colors
                currentEmissionColor = Color.Lerp(currentEmissionColor, exitEmissionColor, Time.deltaTime / exitTransitionTime);
                currentBaseColor = Color.Lerp(currentBaseColor, exitBaseColor, Time.deltaTime / exitTransitionTime);

                material.SetColor("_EmissionColor", currentEmissionColor);
                material.SetColor("_BaseColor", currentBaseColor);
            }
        }
    }
}
