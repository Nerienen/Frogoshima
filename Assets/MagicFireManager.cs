using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFireManager : MonoBehaviour
{
    public ParticleSystem fireParticleSystem;
    public bool thereIsFuel = true;

    private void Start()
    {
        fireParticleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (thereIsFuel)
        {
            fireParticleSystem.Play();
        }
        else
        {
            fireParticleSystem.Stop();
        }
    }
}
