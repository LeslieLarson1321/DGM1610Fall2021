using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    
    public float moveSpeed;                                     // Player's Movement Speed in Units Per Second.
    public float jumpForce;                                     // Force Applied Upwards.

    public int curHp;
    public int maxHp;


    [Header("Mouse Look")]
    
    public float lookSensitivity;                               // Mouse Movement (Perspective) Sensitivity.

    public float maxLookX;                                      // Lowest Angle Player Can Look From
    public float minLookX;                                      // Highest Angle

    private float rotx;                                         // Current X Rotation of the Camera.

    private Camera camera;

    private Rigidbody rb;

    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting Components:
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Applies damage to the player.

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        
        if(curHp = 0)
            Die();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();      
        if(Input.GetButton("Fire1"))           // Creates the fire button.
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
      
        if(Input.GetButtonDown("Jump"))          // Jump Button
            Jump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;          // (Causes speed of player movement to appear.)
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        Vector3 dir = transform.right * x + transform.forward * z;       // Moves direction relative to camera.

         // Old Code:    rb.velocity = new Vector3(x, rb.velocity.y, z);
        
        dir.y = rb.velocity.y;                             // Adds Direction to Jump
        rb.velocity = dir;

    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;               // Camera angle sensitivity
            // Old Code:    rotx = rotx + Input.GetAxis("Mouse Y") * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotx = Mathf.Clamp(rotx, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotx, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray,1.1f))                                   // Adds Force to Jump.
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
