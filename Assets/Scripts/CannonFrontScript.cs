using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFrontScript : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float projectileSpeed = 20f;
    public int projectileDamage = 30;

    public float rotationSpeed = 5f;
    public float maxAngle = 45f;
    public float minAngle = -45f;

    public Transform cannonTransform;
    public LayerMask layerMask;
    public Camera myCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 cannonPosition = cannonTransform.position;

            Vector3 direction = (mousePosition - cannonPosition).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // angle = Mathf.Clamp(angle, minAngle, maxAngle);

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            cannonTransform.rotation = Quaternion.Slerp(cannonTransform.rotation, rotation, rotationSpeed * Time.deltaTime);

            GameObject projectile = Instantiate(projectilePrefab, cannonPosition, Quaternion.identity);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = direction * projectileSpeed;

            //Projectile projectileScript = projectile.GetComponent<Projectile>();
            //projectileScript.damage = projectileDamage;
            
        }
    }
}


