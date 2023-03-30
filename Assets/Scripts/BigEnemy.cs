using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public GameObject flyer;
    public float spawnTimer = 3f;

    private Transform playerTransform;

    public float enemySpeed = 0f;

    public float aggroRange = 200f;
    bool playerNear = false;
    bool canSpawn = true;

    // Set a timer for the distance check
    float distanceCheckTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator whenSpawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        spawnTimer = Random.Range(3, 7);
        canSpawn = true;
    }

    void Spawn()
    {
        Instantiate(flyer, transform.position, transform.rotation);
        StartCoroutine(whenSpawn());
    }
   
    void Update()
    {
        // Decrement the distance check timer
        distanceCheckTimer -= Time.deltaTime;

        // Check the distance to the player if the timer has elapsed
        if (distanceCheckTimer <= 0)
        {
            // Get a reference to the enemy's transform component
            Transform enemyTransform = this.transform;

            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = playerTransform.position - enemyTransform.position;

            // Calculate the distance between the enemy and the player
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if the distance to the player is less than 100
            if (distanceToPlayer < aggroRange)
            {
                playerNear = true;

                // Normalize the direction vector to get a unit vector
                directionToPlayer.Normalize();
            }
            else
            {
                playerNear = false;
            }

            // Reset the distance check timer
            distanceCheckTimer = 0.5f;
        }

        if (playerNear)
        {
            if (canSpawn == true)
            {
                Spawn();
                canSpawn = false;
            }

        }
    }


}


