using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float movementSpeed = 1f;

    private void Update()
    {
        // Move the trash objects towards the destination point
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }
}
