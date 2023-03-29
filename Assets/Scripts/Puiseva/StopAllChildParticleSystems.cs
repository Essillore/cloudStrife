using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllChildParticleSystems : MonoBehaviour
{
    public GameObject aetherStreamParticles;
    public void StopAllChildParticles()
    {
        foreach (Transform child in aetherStreamParticles.transform)
        {
            // Get the particle system component on the child object
            ParticleSystem particles = child.GetComponent<ParticleSystem>();

            // If the child object has a particle system, stop it
            if (particles != null)
            {
                particles.Stop();
            }
            child.gameObject.GetComponent<StopAllChildParticleSystems>()?.StopAllChildParticles();
        }
    }
}
