using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherOrb : MonoBehaviour
{
    public int healAmount = 50;

    public AudioClip pickUp;
    AudioSource audioSource;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (other.GetComponent<PlayerHealth>().currentHealth > 0)
            {
                audioSource.PlayOneShot(pickUp, 0.5F);

                playerHealth.Heal(healAmount);
                Destroy(transform.root.gameObject);
            }
        }
    }

}
