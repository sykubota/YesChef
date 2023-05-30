using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritechanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    public Sprite newSprite4;

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            //timer with oscilating change sprite?
            ChangeSprite(newSprite1);
        }

        
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { 
            ChangeSprite(newSprite2);
        }
        
        
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) { 
            ChangeSprite(newSprite3);
        }


        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            ChangeSprite(newSprite4);
        }
    }

    void ChangeSprite(Sprite newSprite) {
        spriteRenderer.sprite = newSprite; 
    }
}
