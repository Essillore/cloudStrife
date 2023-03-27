using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 3f;
    public float rotateSpeed = 10f;
    public float horizontal;
    public float vertical;
    public float depth;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        depth = Input.GetAxis("Depth");
        transform.Translate( new Vector3(0, playerSpeed * Time.deltaTime * vertical, playerSpeed * Time.deltaTime * depth));

        transform.Rotate(Vector3.up, horizontal * rotateSpeed * Time.deltaTime);

    }
}
