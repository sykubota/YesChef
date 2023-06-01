using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theocontroller : MonoBehaviour {
   public float speed = 5.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { 
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) { 
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }


        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}