using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 5.0f;
    public float bottomBound = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }

    }
}