using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isFishSaved;
    
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isFishSaved = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isFishSaved)
        {
            print("You've saved the fish!");
        }
    }
}