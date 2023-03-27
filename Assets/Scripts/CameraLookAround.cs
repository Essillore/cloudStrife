using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour
{
    public float rotationX = 0f;
    public float rotationY = 0f;

    public float sensitivity = 10f;
    public float orbitDamping = 10f;

    public Transform target;


    // Update is called once per frame
    void Update()
    {
        // transform.position = target.position;

        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        // rotationY = Mathf.Clamp(rotationY, 0f, 88f);

        Quaternion QT = Quaternion.Euler(rotationX, rotationY, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
       
       // transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

    }
}
