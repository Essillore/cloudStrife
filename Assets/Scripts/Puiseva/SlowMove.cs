using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        // this.GetComponent<Rigidbody>().velocity = ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // Calculate the new x position based on the current position and speed
        float newZPosition = position.z + speed * Time.deltaTime;

        // Set the new position of the object
        transform.position = new Vector3(position.x, position.y, newZPosition);
    }
}
