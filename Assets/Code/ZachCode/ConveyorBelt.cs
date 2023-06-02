using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed;

    void Start() 
    {
       GetComponent<SpriteRenderer>().transform.Rotate(90, -90,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0);
    }
}
