using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 0.5f;

    private float timer;

    private void Update()
    {
        // Increment the timer.
        timer += Time.deltaTime;

        // If the timer has exceeded the spawn interval, spawn the object and reset the timer.
        if (timer >= spawnInterval)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
