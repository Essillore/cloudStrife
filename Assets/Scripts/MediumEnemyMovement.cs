using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyMovement : MonoBehaviour
{
    // Private variable to store a reference to the player's transform component
    private Transform playerTransform;

    public float enemySpeed = 20f;

    public float aggroRange = 100f;
    public float shootRange = 30;
    bool chasingPlayer = false;
    public float distanceToPlayer;

    // Set a timer for the distance check
    float distanceCheckTimer = 0.5f;

    public GameObject enemyBulletPrefab;
    public float bulletSpeed = 1000;

    public bool enemyCanFire = true;
    public float enemyShootCD = 1;
    public GameObject enemyCannonLocation;


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
            distanceToPlayer = directionToPlayer.magnitude;

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

            if (distanceToPlayer <= shootRange)
            {
                this.transform.position = this.transform.position;

                if (enemyCanFire == true)
                {
                    Shoot();
                    StartCoroutine(Cooldown());
                    enemyCanFire = false;

                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(enemyShootCD);
        enemyCanFire = true;
    } 

public void Shoot()
    {
        print("Shoot");

        GameObject enemyBullet = Instantiate(enemyBulletPrefab, enemyCannonLocation.transform.position, enemyCannonLocation.transform.rotation);
        enemyBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
