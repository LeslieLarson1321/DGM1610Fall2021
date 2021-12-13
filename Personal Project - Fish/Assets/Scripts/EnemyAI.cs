
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform fish;
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
        Vector2 direction = fish.position - transform.position;
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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Fish"))
        {
            print("The fish has been caught.");
            Destroy(gameObject,0.5f);
        }
    }
}