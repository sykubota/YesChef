using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 8;
    public GameObject spriteContainer; // Reference to the child object holding the sprite renderer

    // Flag indicating if it's the second spawner.
    public bool isSecondSpawner = false;

    void Start()
    {
        // Rotate the child object instead of the sprite renderer directly
        spriteContainer.transform.Rotate(90, -90, 0);
    }

    void Update()
    {
        if (isSecondSpawner)
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        else
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
