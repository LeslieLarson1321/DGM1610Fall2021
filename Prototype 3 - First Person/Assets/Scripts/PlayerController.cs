using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;                                     // Player's Movement Speed in Units Per Second.
    public float jumpForce;                                     // Force Applied Upwards.
    public float lookSensitivity;                               // Mouse Movement (Perspective) Sensitivity.

    public float maxLookX;                                      // Lowest Angle Player Can Look From
    public float minLookX;                                      // Highest Angle

    private float rotx;                                         // Current X Rotation of the Camera.

    private Camera camera;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting Components:
        camera = camera.main;
        rb = getComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void camLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
            // rotx = rotx + Input.GetAxis("Mouse Y") * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity;
    }
}
