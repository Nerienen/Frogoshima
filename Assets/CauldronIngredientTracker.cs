using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronIngredientTracker : MonoBehaviour
{
    // Fire Particle Sys
    public ParticleSystem fireParticleSystem;
    public bool thereIsFuel = false;

    // Other
    public int growthBallCount = 0;
    public int glueBallCount = 0;

    // Fumes
    public ParticleSystem growthFumes;
    public ParticleSystem glueFumes;

    private List<GameObject> lilypadIngredients = new List<GameObject>();
    private List<GameObject> glueberryIngredients = new List<GameObject>();

    private Coroutine burningCoroutine = null;

    // Balls to instantiate
    public GameObject growthBall;
    public GameObject glueBall;

    // Position to instantiate at
    public Transform ballSpawnPoint;

    // Scale of the instantiated balls
    public float ballScale = 1.0f;

    // Fuel tracker
    public FuelTracker fuelTracker;

    // Fire pps
    private void Update()
    {
        // Fire bool
        if (fuelTracker.GetObjectCount() >= 1)
        {
            thereIsFuel = true;
            fireParticleSystem.Play();
        }
        else
        {
            thereIsFuel = false;
            fireParticleSystem.Stop();
        }

        // Burning lilypad ingredients ☘️
        if (thereIsFuel && lilypadIngredients.Count > 0 && burningCoroutine == null)
        {
            burningCoroutine = StartCoroutine(BurnLilypadIngredients());
        }

        // Burning glueberry ingredients 🍅
        if (thereIsFuel && glueberryIngredients.Count > 0 && burningCoroutine == null)
        {
            burningCoroutine = StartCoroutine(BurnGlueberryIngredients());
        }

    }

    // Other
    private void OnTriggerEnter(Collider other)
    {

        //☘️
        if (other.CompareTag("LilypadIngredient"))
        {
            growthBallCount++;
            lilypadIngredients.Add(other.gameObject);
        }


        //🍅
        if (other.CompareTag("GlueberryIngredient"))
        {
            glueBallCount++;
            glueberryIngredients.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        //☘️
        if (other.CompareTag("LilypadIngredient"))
        {
            growthBallCount--;
            lilypadIngredients.Remove(other.gameObject);
        }

        //🍅
        if (other.CompareTag("GlueberryIngredient"))
        {
            glueBallCount--;
            glueberryIngredients.Add(other.gameObject);
        }
    }

    //☘️

    private IEnumerator BurnLilypadIngredients()
    {
        while (lilypadIngredients.Count > 0)
        {
            growthFumes.Play();
            GameObject ingredient = lilypadIngredients[0];
            growthBallCount--;
            lilypadIngredients.RemoveAt(0);
            ingredient.SetActive(false);

            // Instantiate growthBall prefab at specified transform with specified scale
            GameObject ball = Instantiate(growthBall, ballSpawnPoint.position, Quaternion.identity);
            ball.transform.localScale = Vector3.one * ballScale;

            yield return new WaitForSeconds(5f);
        }
        burningCoroutine = null;
    }

    //🍅

    private IEnumerator BurnGlueberryIngredients()
    {
        while (glueberryIngredients.Count > 0)
        {
            glueFumes.Play();
            GameObject ingredient = glueberryIngredients[0];
            glueBallCount--;
            glueberryIngredients.RemoveAt(0);
            ingredient.SetActive(false);

            // Instantiate cleanserBall prefab at specified transform with specified scale
            GameObject ball = Instantiate(glueBall, ballSpawnPoint.position, Quaternion.identity);
            ball.transform.localScale = Vector3.one * ballScale;

            yield return new WaitForSeconds(5f);
        }
        burningCoroutine = null;
    }

}
