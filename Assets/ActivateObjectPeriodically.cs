using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectPeriodically : MonoBehaviour
{
    public GameObject objectToActivate;

    private float timeCounter = 0f;
    private bool isActive = false;

    private void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= 1f)
        {
            timeCounter -= 1f;
            isActive = !isActive;

            objectToActivate.SetActive(isActive);
            if (isActive)
            {
                Invoke("DeactivateObject", 0.1f);
            }
        }
    }

    private void DeactivateObject()
    {
        objectToActivate.SetActive(false);
    }
}
