using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
        public int damage = 20;

    private void Start()
    {
        StartCoroutine(autoDestroyProjectile());
    }
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
            Debug.Log("has damaged enemy");

                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                if (other.GetComponent<EnemyHealth>().currentHealth > 0)
                {
                    enemyHealth.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            else if (other.transform.CompareTag("Spire"))
            {
            Debug.Log("has damaged spire");

            Spire spire = other.transform.GetComponent<Spire>();
            if (other.transform.GetComponent<Spire>().spireHealth > 0)
            {
                spire.TakeDamage(damage);
            }
            // Destroy(gameObject);
         }
        
        
    /*private void OnCollisionEnter(Collision other)
    {
        print("Hit something!");
        if (other.transform.CompareTag("Spire"))
        {
            Debug.Log("has damaged spire");

            Spire spire = other.transform.GetComponent<Spire>();
            if (other.transform.GetComponent<Spire>().spireHealth > 0)
            {
                 spire.TakeDamage(damage); 
            }
            // Destroy(gameObject);
        }*/
    }


    IEnumerator autoDestroyProjectile()
    {
        yield return new WaitForSeconds(11);
        Destroy(gameObject);
    }


}

