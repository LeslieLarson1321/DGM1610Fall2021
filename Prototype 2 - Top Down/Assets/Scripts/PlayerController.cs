using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 50.0f;
    public float hInput;
    public float vInput;

    public float xRange = 5f;
    public float yRange = 5f;

    public GameObject projectile;

    public Transform launcher;

    public new Vector3 offset = new Vector3(0,1,0);


    // public float health
   
    // Update is called once per frame.
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
    
            // Created a boundary on the left (-x) side.
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
            // Created a boundary on the right (x) side.
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
            // MY CODE... AAAH oh no
            // Created a boundary on the bottom (-y) side.
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
            // Created a boundary on the top (y) side.
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
                // Oh, wait, this wasn't as hard as I thought it'd be.

                // Creating the white spheres that shoot when you press "Space"; connected to Launcher
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
        }
    }
}