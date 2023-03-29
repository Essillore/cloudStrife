using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SideCannon : MonoBehaviour
{
    public GameObject sideProjectilePrefab;
    public float projectileSpeed = 1000f;
    public Camera myCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject projectile = Instantiate(sideProjectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

            /*if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
            */
        }

    }

}