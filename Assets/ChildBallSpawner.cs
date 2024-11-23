using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBallSpawner : MonoBehaviour
{
    public float spawnInterval = 2f; // the time interval between setting objects active
    public float checkInterval = 3f; // the time interval between checking for new children
    private List<Transform> childList = new List<Transform>();
    private bool isChecking = true;

    public OpenCorkBallSpawnerAlchemy openCorkScript;

    private void Start()
    {
        StartCoroutine(SpawnChildren());
        StartCoroutine(CheckForNewChildren());
    }

    IEnumerator SpawnChildren()
    {
        while (isChecking)
        {
            if (openCorkScript.theCorkIsOpen)
            {
                for (int i = 0; i < childList.Count; i++)
                {
                    if (!childList[i].gameObject.activeSelf)
                    {
                        childList[i].gameObject.SetActive(true);
                        childList[i].position = transform.position;

                        yield return new WaitForSeconds(spawnInterval);
                    }
                }
            }

            yield return null;
        }
    }

    IEnumerator CheckForNewChildren()
    {
        while (isChecking)
        {
            if (openCorkScript.theCorkIsOpen)
            {
                UpdateChildList();
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }

    // Updates the child list in case new children have been added
    private void UpdateChildList()
    {
        childList.Clear();

        foreach (Transform child in transform)
        {
            childList.Add(child);
        }
    }
}
