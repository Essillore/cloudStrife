using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    public int damage = 20;

    private void Start()
    {
        StartCoroutine(autoDestroyProjectile());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("has damaged player");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (other.GetComponent<PlayerHealth>().currentHealth > 0)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
  
    }


    IEnumerator autoDestroyProjectile()
    {
        yield return new WaitForSeconds(11);
        Destroy(gameObject);
    }


}