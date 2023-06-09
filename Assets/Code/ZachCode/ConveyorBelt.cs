using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 8;
    public GameObject spriteContainer; // Reference to the child object holding the sprite renderer

    // Flag indicating if it's the second spawner.
    public bool isSecondSpawner = false;

    // Flag indicating if the object should move.
    private bool shouldMove = true;

    void Start()
    {
        // Rotate the child object instead of the sprite renderer directly
        spriteContainer.transform.Rotate(90, -90, 0);

        if (isSecondSpawner)
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate the spawner if it's the second one
    }

    void Update()
    {
        if (shouldMove)
        {
            if (isSecondSpawner)
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            else
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    // Method to control the movement of the object.
    public void SetMoveState(bool move)
    {
        shouldMove = move;
    }
}
