using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaLiquidBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {


        //Mana + Fire
        if (collision.gameObject.CompareTag("FireLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("MagicDetectionBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //Mana + Cleanser
        if (collision.gameObject.CompareTag("CleanserLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("SpeedBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //Mana + GoldStar
        if (collision.gameObject.CompareTag("GoldStarLiquid"))
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
