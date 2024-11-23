using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLiquidBehaviour : MonoBehaviour
{
    
   
     private void OnCollisionEnter(Collision collision)
    {



        //Fire + Mana
        if (collision.gameObject.CompareTag("ManaLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("MagicDetectionBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //Fire + GoldStar
        if (collision.gameObject.CompareTag("GoldStarLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("DarkVisionBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }


        //Fire + Cleanser
        if (collision.gameObject.CompareTag("CleanserLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("FireResistanceBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }


    }



   


}
