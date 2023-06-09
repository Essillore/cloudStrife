using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 15f;
    public float playerVerticalSpeed = 10f;
    public float rotateSpeed = 30f;
    public float horizontal;
    public float vertical;
    public float depth;

    public bool endState = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        if (endState == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            depth = Input.GetAxis("Depth");
            transform.Translate(new Vector3(0, playerVerticalSpeed * Time.deltaTime * vertical, playerSpeed * Time.deltaTime * depth));

            transform.Rotate(Vector3.up, horizontal * rotateSpeed * Time.deltaTime);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
