using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueLiquidBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        //Glue + Water
        if (collision.gameObject.CompareTag("WaterLiquid"))
        {
            GameObject ballPrefabPoison = GameObject.Find("CleanserBall");
          
            if (ballPrefabPoison != null)
            {
                GameObject ball = Instantiate(ballPrefabPoison, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

    }
}
