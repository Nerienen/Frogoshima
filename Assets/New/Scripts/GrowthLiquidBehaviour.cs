using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthLiquidBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       
        //GoldStar + Growth
        if (collision.gameObject.CompareTag("GoldStarLiquid"))
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

    }
}
