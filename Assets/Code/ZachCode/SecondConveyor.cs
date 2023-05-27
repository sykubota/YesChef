using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondConveyor : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    private bool isMoving = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(0, 0, -moveSpeed);
        }
            // Move the object by 1 unit in the X direction
          

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