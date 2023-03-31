using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;

    public GameObject pickUp;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //Explosion
            Instantiate(explosion, transform.position, transform.rotation);

            //PickUp
            Instantiate(pickUp, transform.position, transform.rotation);

            Destroy(transform.root.gameObject);
        }
    }

}