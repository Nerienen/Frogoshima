using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStarLiquidBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding object tag: " + collision.gameObject.tag);


        //GoldStar + Growth
        if (collision.gameObject.CompareTag("GrowthLiquid"))
        {
            GameObject ballPrefabPoison = GameObject.Find("PoisonBall");
            if (ballPrefabPoison == null)
            {
                Debug.Log("PoisonBall prefab not found!");
            }
            if (ballPrefabPoison != null)
            {
                GameObject ball = Instantiate(ballPrefabPoison, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }




        //GoldStar + Fire
        if (collision.gameObject.CompareTag("FireLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("DarkVisionBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //GoldStar + Mana
        if (collision.gameObject.CompareTag("ManaLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("GrowthBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

    }
}
