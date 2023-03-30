using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public bool activelyHealing;
    public int seededSpires = 0;
    public int destroyedSpires = 0;

    GameObject endingScreen;
    GameObject winScreen;
    GameObject gameUI;

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
            gameUI.SetActive(false);
            endingScreen.SetActive(true);
            //spawn death explosion here, before destroying

            Destroy(transform.root.gameObject);
        }

        if (seededSpires >= 17)
        {
            gameUI.SetActive(false);
            winScreen.SetActive(true);
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
