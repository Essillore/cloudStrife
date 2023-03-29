using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
        public int damage = 20;

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
        }
    private void Update()
    {
        StartCoroutine(autoDestroyProjectile());
    }
    IEnumerator autoDestroyProjectile()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }


}

