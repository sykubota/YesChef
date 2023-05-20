using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ConveyorBelt : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving = true; // Track whether the conveyor belt is currently moving or not

    void Start()
    {

    }

    void Update()
    {
        if (isMoving)
        {
            // Move the object by 1 unit in the X direction
            transform.Translate(0, 0, moveSpeed);
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public void ResumeMoving()
    {
        isMoving = true;
    }
}
