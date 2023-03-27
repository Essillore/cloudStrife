using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    public float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, transform.position, delay * Time.deltaTime);
    }
}
