// This script moves a game object left, right, forwards, backwards...
// using input from keyboard/gamepad (set in the Input Manager)
// 'Update' Method is used for the Input (keyboard/Gamepad)
// 'Fixed' Method is used for physics movement
// The Input is 'Normalized' to prevent faster diagonal movement
// 'Time.fixedDeltaTime' is used to keep the physics framrate consistant on all devices

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    // Add the variables
    public float speed =1000f; // Speed variable
    public static Rigidbody rb; // Set the variable 'rb' as Rigibody
    public Vector3 movement;
    public static string result = "0";

    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,-20.0f,0f);
    }




    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        // We call the function 'moveCharacter' in FixedUpdate for Physics movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f,verticalInput);
        rb.velocity = movement.normalized * speed * Time.deltaTime + new Vector3(0f,rb.velocity.y,0f);

       // rb.velocity =movement * speed * Time.deltaTime;

    }



    // 'moveCharacter' Function for moving the game object
    void OnCollisionEnter(Collision other)
    {
        result=other.transform.tag;
        switch(other.transform.tag){
           case "Wall1":
            transform.GetComponent<Renderer>().material.color = Color.red;
            break;
           case "Wall2":
            transform.GetComponent<Renderer>().material.color = Color.blue;
            break;
           case "Wall3":
            transform.GetComponent<Renderer>().material.color = Color.yellow;
            break;
           case "Wall4":
             transform.GetComponent<Renderer>().material.color = Color.black;
             break;
     }
       
    }
    void OnCollisionExit(Collision other)
    {
        result = "0";
        
        transform.GetComponent<Renderer>().material.color = Color.white;

    }

}