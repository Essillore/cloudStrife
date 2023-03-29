using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMouseaim : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    public Camera myCamera;
    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
     //   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);

        if (Input.GetButtonDown("Fire1") && playerHealth.currentHealth > 1)
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transform.LookAt(hit.point);
            }

            playerHealth.TakeDamage(1);

            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
            
            /*if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
            */

        }

    }

}