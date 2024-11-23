using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyGlass2BallStorer : MonoBehaviour
{
    public GameObject instantiationPosition;
    public string liquidBallLayerName = "LiquidBall";

    private int liquidBallLayerIndex;

    private void Start()
    {
        // Get the layer index of the liquidBallLayerName
        liquidBallLayerIndex = LayerMask.NameToLayer(liquidBallLayerName);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's game object is on the liquidBallLayer
        if (other.gameObject.layer == liquidBallLayerIndex)
        {
            // Deactivate the game object
           //april 18  other.gameObject.SetActive(false);

            // Make the game object a child of the instantiationPosition game object
            other.transform.SetParent(instantiationPosition.transform);
        }
    }
}
