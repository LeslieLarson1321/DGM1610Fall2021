using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player") && gameManager.hasKey == true)
        {
            print("Oh no! I've been foiled! You unlocked the door with the key!");
            gameManager.isDoorLocked = false;
        }
        else
        {
            print("The door is locked. YOU CANNOT ESCAPE!!!! BWAHAHAHA, et cetera.");
        }
    }
}
