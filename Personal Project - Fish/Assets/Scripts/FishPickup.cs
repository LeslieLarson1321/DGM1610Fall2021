using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPickup : MonoBehaviour
{
    public string pickupName;

    public int amount;

    public GameManager gameManager;

    public Vector2 movement;
 
    public Transform boundary;
    public float speed = 5f;

 void Update()
   {
       transform.Rotate(Vector3.back * 10 * Time.deltaTime);
       transform.Translate(Vector3.forward * 2 * Time.deltaTime);
   }

    void OnTriggerEnter2D(Collider2D other)
    {
       print("You've saved the fish!");
       gameManager.hasKey = true;
       Destroy(gameObject);
    }
}