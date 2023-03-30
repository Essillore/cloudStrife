using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyMovement : MonoBehaviour
{
    // Private variable to store a reference to the player's transform component
    private Transform playerTransform;

    public float enemySpeed = 1000f;

    public float aggroRange = 100f;
    bool chasingPlayer = false;

    // Set a timer for the distance check
    float distanceCheckTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
                chasingPlayer = true;

                // Normalize the direction vector to get a unit vector
                directionToPlayer.Normalize();
            }
            else
            {
                chasingPlayer = false;
            }

            // Reset the distance check timer
            distanceCheckTimer = 0.5f;
        }

        if (chasingPlayer)
        {
            // Face towards the player
            this.transform.LookAt(playerTransform);

            // Move the enemy in the direction of the player
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerTransform.position, enemySpeed * Time.deltaTime / 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(50);

                Destroy(gameObject);
            }
        }
    }

}
