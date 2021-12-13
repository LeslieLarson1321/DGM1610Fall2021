using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{

    public float moveSpeed;

    private Vector2 movement;

    public Rigidbody2D rb;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        
    }

   /// void MoveEnemy(Vector2 direction)
   /// {
   ///     ---((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
   /// }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Portal"))
        {
            print("Fish Saved!");
            Destroy(gameObject,0.5f);
            // increase score count.
    
        }
    }
}