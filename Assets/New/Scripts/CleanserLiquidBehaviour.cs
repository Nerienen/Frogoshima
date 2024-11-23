using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanserLiquidBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {


        //Cleanser + Mana
        if (collision.gameObject.CompareTag("ManaLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("SpeedBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //Cleanser + Fire
        if (collision.gameObject.CompareTag("FireLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("FireResistanceBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

        //Cleanser + Poison
        if (collision.gameObject.CompareTag("PoisonLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("PoisonResistanceBall");
            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }
    }
}
