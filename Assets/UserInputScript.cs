using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0f, v).normalized;

        if (dir.magnitude >= 0.1) {
            controller.Move(dir * speed * Time.deltaTime);
        }
    }
}
