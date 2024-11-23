using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTracker : MonoBehaviour
{
    public int objectCount = 0;
    private List<GameObject> objectsInside = new List<GameObject>();

    // Reference to the CauldronIngredientTracker script
    public CauldronIngredientTracker cauldronIngredientTracker;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.activeSelf || !other.CompareTag("MagicCoal")) return;

        objectCount++;
        objectsInside.Add(other.gameObject);

        // Check if there is fuel and set the boolean accordingly
        if (objectCount >= 1)
        {
            cauldronIngredientTracker.thereIsFuel = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("MagicCoal")) return;

        objectsInside.Remove(other.gameObject);
        objectCount--;

        // Check if there is fuel and set the boolean accordingly
        if (objectCount == 0)
        {
            cauldronIngredientTracker.thereIsFuel = false;
        }
    }

    public int GetObjectCount()
    {
        // Clean up the list of objects inside in case some of them have been destroyed or become inactive
        objectsInside.RemoveAll(item => item == null || !item.activeSelf);

        // Update object count based on the cleaned-up list
        objectCount = objectsInside.Count;

        return objectCount;
    }

}
