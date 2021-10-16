using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Gives Gravity Component to Enemy.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
            // Sets degrees of movement to whole numbers
        movement = direction;
        // 
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
         //   // Makes it so the projectile colliding with the enemy will destroy it.
    //void OnTriggerEnter2D(Collider2D collision)
   //{
         //   // Enemy destroyed only if the object hitting it has the tag "Projectile"
       //if(collision.CompareTag("Projectile"))
        //{
            //Destroy(gameObject);
        //}
     //}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            print("Projectile Hit Enemy");
            Destroy(gameObject,0.5f);
                // Yep
                // This last line's good for death animations! (Delays the death)
        }
    }
}
