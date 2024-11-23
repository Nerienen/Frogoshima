using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public int coinCount = 0;
    public ParticleSystem particleSystem;
    public Light lightToControl;
    public List<GameObject> coinsInside = new List<GameObject>();

    private float lightIntensityTarget = 0f;
    private float lightIntensityVelocity = 5f;

    private void Start()
    {
        StartCoroutine(CheckForInactiveCoins());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            coinsInside.Add(other.gameObject);
        }

        // Check if particle system needs to be played
        if (coinCount > 0 && particleSystem != null && !particleSystem.isPlaying)
        {
            particleSystem.Play();
        }

        // Update light intensity target
        if (coinCount == 1)
        {
            lightIntensityTarget = 1.3f;
        }

        // Call OnTransformChildrenChanged to update colliders
        transform.parent.SendMessage("OnTransformChildrenChanged", SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount--;
            coinsInside.Remove(other.gameObject);
        }

        // Check if particle system needs to be stopped
        if (coinCount == 0 && particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }

        // Update light intensity target
        if (coinCount == 0)
        {
            lightIntensityTarget = 0f;
        }

        // Call OnTransformChildrenChanged to update colliders
        transform.parent.SendMessage("OnTransformChildrenChanged", SendMessageOptions.DontRequireReceiver);
    }


    private IEnumerator CheckForInactiveCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            for (int i = coinsInside.Count - 1; i >= 0; i--)
            {
                if (!coinsInside[i].activeSelf)
                {
                    coinsInside.RemoveAt(i);
                    coinCount--;
                }
            }

            // Smoothly update light intensity
            if (lightToControl != null)
            {
                lightToControl.intensity = Mathf.SmoothDamp(lightToControl.intensity, lightIntensityTarget, ref lightIntensityVelocity, 0.05f);
            }

            // Stop particle system if coinCount is 0
            if (coinCount == 0 && particleSystem != null && particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }

    public int GetCoinCount()
    {
        // Remove any inactive coins from the list
        coinsInside.RemoveAll(item => item == null || !item.activeSelf);

        // Update coin count based on the cleaned-up list
        coinCount = coinsInside.Count;

        return coinCount;
    }

    public void RemoveCoin(GameObject coin)
    {


        if (coinsInside.Contains(coin))
        {
            GameObject coinToDisable = coinsInside[0];

            coinsInside.Remove(coin);
            coinCount--;
            coinToDisable.SetActive(false);

            // Call OnTransformChildrenChanged to update colliders
            transform.parent.SendMessage("OnTransformChildrenChanged", SendMessageOptions.DontRequireReceiver);
        }
    }


}
