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

    public GameObject endingScreen;
    public GameObject winScreen;
    public GameObject gameUI;
    public GameObject playerMovementObject;
    public GameObject playerCameraObject;
    public GameObject cannonObject;
    public GameObject sideCannonObjectRight;
    public GameObject sideCannonObjectLeft;

    public AudioClip pickUp;

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
            //Cursor.lockState = CursorLockMode.None;
            //spawn death explosion here, before destroying

            Destroy(transform.root.gameObject);
        }
    }



    public void FixedUpdate()
    {
        if (activelyHealing == true)
        {
            Heal(1);
        }
                if (seededSpires >= 18)
        {
            gameUI.SetActive(false);
            winScreen.SetActive(true);
            // Cursor.lockState = CursorLockMode.None;
            playerMovementObject.GetComponent<PlayerMovement>().endState = true;
            playerCameraObject.GetComponent<Camera2LookAround>().endState = true;
            sideCannonObjectRight.GetComponent<SideCannon>().endState = true;
            sideCannonObjectLeft.GetComponent<SideCannon>().endState = true;
            cannonObject.GetComponent<CannonMouseaim>().endState = true;
        }
    }

    public void Update()
    {
       /* if (Input.GetKeyDown("k"))
        {
            // if (unbroken == true) { spireHealth -= 10f; }
            seededSpires = 18;
        }*/
    }


    public void Heal (int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StaticSpire"))
        {
            print("Yes");
           // PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (currentHealth < 1000)
            {
                GetComponent<AudioSource>().PlayOneShot(pickUp, 0.5f);

                Heal(other.GetComponent<AetherOrb>().healAmount);
                /*if (other.gameObject.transform.parent != null)
                {
                    // Keep destroying parents until there are no more left
                    Transform parentTransform = other.gameObject.transform.parent;
                    while (parentTransform != null)
                    {
                        Destroy(parentTransform.gameObject);
                        parentTransform = parentTransform.parent;
                    }
                }*/
                Destroy(other.gameObject.transform.parent.gameObject);
                //Destroy(other.gameObject);
            }
        }
    }

}
