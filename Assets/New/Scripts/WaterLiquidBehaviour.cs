using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLiquidBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        //Glue + Water
        if (collision.gameObject.CompareTag("GlueLiquid"))
        {
            GameObject ballPrefab = GameObject.Find("CleanserBall");

            if (ballPrefab != null)
            {
                GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

    }
}
