using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonLiquidBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        //Poison + Cleanser
        if (collision.gameObject.CompareTag("CleanserLiquid"))
        {
            GameObject ballPrefabPoison = GameObject.Find("PoisonResistanceBall");

            if (ballPrefabPoison != null)
            {
                GameObject ball = Instantiate(ballPrefabPoison, transform.position, transform.rotation);
                ball.transform.localScale = transform.localScale;
            }

            gameObject.SetActive(false);
        }

    }
}
