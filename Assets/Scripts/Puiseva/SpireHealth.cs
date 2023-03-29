using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpireHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;


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
            //deathAnimation
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Spire"))
        {
            Debug.Log("has damaged spire");

            Spire spire = other.transform.GetComponent<Spire>();
            if (other.transform.GetComponent<Spire>().spireHealth > 0)
            {
               // spire.TakeDamage(damage);  UNCOMMENT THIS
            }
           // Destroy(gameObject);
        }
    }

}