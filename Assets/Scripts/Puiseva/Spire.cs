using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Spire : MonoBehaviour
{

    public bool unbroken = true;
    public bool broken = false;
    public bool seeded = false;
    public bool cherryTree = false;

    public bool healing = false;

    bool timerOnStream = false;
    float timerOnStreamTime = 5f;

    public float spireHealth = 100f;

    public GameObject unBrokenMesh; // intact spire model
    public GameObject brokenMesh; // broken spire model
    public GameObject treeMesh; // tree model
    public GameObject cherryTreeMesh;
    public GameObject cherryTreeParticles;
    public GameObject aetherExplosionParticles; // aether explosion on break
    public GameObject aetherStreamParticles; // aether stream while broken and unseeded
    public GameObject rechargeColliderObject; // object to hold capsule collider for health recharge area

    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
           // if (unbroken == true) { spireHealth -= 10f; }
            if (broken == true) { PlantSeed(); }
        }

        if (timerOnStream == true)  // this countdowns for stopped particles to end, before complete deactivation for ribbons
        {
            if (timerOnStreamTime < 0f)
            { timerOnStream = false;
            aetherStreamParticles.SetActive(false);}

            timerOnStreamTime -= Time.deltaTime;
        }

        if (unbroken == true && spireHealth <= 0f)
        {
            ChangeSpireState();
        }
    }

    public void ChangeSpireState()
    {
        if (unbroken == true)
        {
            // hide intact spire and replace with broken spire, reveal effects, activate health recharge area
            brokenMesh.SetActive(true);
            unBrokenMesh.SetActive(false);
            aetherExplosionParticles.SetActive(true);
            aetherStreamParticles.SetActive(true);
            rechargeColliderObject.SetActive(true);
            playerObject.GetComponent<PlayerHealth>().destroyedSpires++;
            // change state
            unbroken = false;
            broken = true;
        }
        else if (broken == true)
        {
            // stop aether stream effect, hide health recharge area, install tree
            aetherExplosionParticles.SetActive(false);
            //aetherStreamParticles.SetActive(false);

            timerOnStream = true; // start countdown to deactivate particle system after stopped particles have died (ribbons don't end so they never stop otherwise)
            this.GetComponent<StopAllChildParticleSystems>().StopAllChildParticles(); // stop all particles for a nice ending

            // aetherStreamParticles.GetComponentInChildren<ParticleSystem>().Stop();
            rechargeColliderObject.SetActive(false);
            if (cherryTree == true)
            { cherryTreeMesh.SetActive(true);
                cherryTreeParticles.SetActive(true);
            }
            else { treeMesh.SetActive(true); }
            healing = false;
            playerObject.GetComponent<PlayerHealth>().activelyHealing = false;
            playerObject.GetComponent<PlayerHealth>().seededSpires++;
            // change state
            broken = false;
            seeded = true;

        }
        else if (seeded == true)
        {

        }
    }
    public void TakeDamage(int amount)
    {
        spireHealth -= amount;

       /* if (currentHealth <= 0)
        {
            //deathAnimation
            Destroy(gameObject);
        }*/
    }

    public void PlantSeed()
    {
        if (healing == true)
        { ChangeSpireState(); }
    }

}

