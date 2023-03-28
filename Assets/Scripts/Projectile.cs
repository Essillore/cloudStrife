using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
        public int damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                //Health enemyHealth = other.GetComponent<Health>();
                //if (enemyHealth != null)
                //{
                //    enemyHealth.TakeDamage(damage);
                //}
                Destroy(gameObject);
            }
        }

}
