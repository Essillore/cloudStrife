using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public bool activelyHealing;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //we're dead
            Destroy(transform.root.gameObject);
        }
    }



    public void FixedUpdate()
    {
        if (activelyHealing == true)
        {
            Heal(1);
        }
    }

    public void Heal (int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }



}
