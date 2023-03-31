using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SideCannon : MonoBehaviour
{
    public GameObject sideProjectilePrefab;
    public float projectileSpeed = 1000f;

    public float abilityCooldown;
    private bool canFire = true;

    public bool endState = false;

    void Start()
    {
        canFire = true;    
    }
    // Update is called once per frame
    void Update()
    {
        if (endState == false)
        {
            if (Input.GetButtonDown("Fire2") && canFire == true)
            {
                canFire = false;
                GameObject projectile = Instantiate(sideProjectilePrefab, transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

                StartCoroutine(Cooldown());

                /*if (hit.transform.CompareTag("Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                }
                */

            }
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(abilityCooldown);
        canFire = true;
    }

}