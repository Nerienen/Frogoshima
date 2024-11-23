using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnoreLayerPotionBox : MonoBehaviour
{
    private void Start()
    {
        // Ignore collisions between this collider and the LiquidBalls layer
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("LiquidBalls"));
    }
}