using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScriptAether : MonoBehaviour
{

    private void FixedUpdate()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, Mathf.Infinity))
        {
            //  transform.position = hit.point;

            transform.position = Vector3.Lerp(transform.position, hit.point, 0.1f);

            if (Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }


        }


    }

}