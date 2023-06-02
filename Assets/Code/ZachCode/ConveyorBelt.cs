using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed;
    public GameObject spriteContainer; // Reference to the child object holding the sprite renderer

    void Start() 
    {
        // Rotate the child object instead of the sprite renderer directly
        spriteContainer.transform.Rotate(90, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0);
    }
}