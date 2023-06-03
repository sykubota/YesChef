//ORIGINAL SCRIPT BY YAE
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

// //SCRIPT THAT WORKED
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpriteChanger : MonoBehaviour
// {
//     public SpriteRenderer spriteRenderer;
//     public Sprite[] upSprites;
//     public Sprite[] leftSprites;
//     public Sprite[] downSprites;
//     public Sprite[] rightSprites;

//     public float spriteChangeInterval = 0.2f; // Time interval between sprite changes
//     private bool isWalking = false; // Indicates whether the character is walking
//     private float timeSinceLastSpriteChange = 0f; // Time elapsed since the last sprite change
//     private int spriteIndex = 0; // Index to keep track of the current sprite

//     void Start()
//     {
//         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
//     }

//     void Update()
//     {
//         // Check if any movement keys are pressed
//         bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

//         if (isMoving && !isWalking)
//         {
//             // Start walking animation
//             isWalking = true;
//             spriteIndex = 0;
//             timeSinceLastSpriteChange = 0f;
//         }
//         else if (!isMoving && isWalking)
//         {
//             // Stop walking animation
//             isWalking = false;
//             ChangeSprite(null); // Set the default sprite when not walking
//         }

//         if (isWalking)
//         {
//             // Increment the time since the last sprite change
//             timeSinceLastSpriteChange += Time.deltaTime;

//             // Check if it's time to change the sprite
//             if (timeSinceLastSpriteChange >= spriteChangeInterval)
//             {
//                 timeSinceLastSpriteChange = 0f;

//                 // Determine the direction of movement based on the keys pressed
//                 if (Input.GetKey(KeyCode.W))
//                 {
//                     // Move up
//                     ChangeSprite(upSprites[spriteIndex]);
//                 }
//                 else if (Input.GetKey(KeyCode.A))
//                 {
//                     // Move left
//                     ChangeSprite(leftSprites[spriteIndex]);
//                 }
//                 else if (Input.GetKey(KeyCode.S))
//                 {
//                     // Move down
//                     ChangeSprite(downSprites[spriteIndex]);
//                 }
//                 else if (Input.GetKey(KeyCode.D))
//                 {
//                     // Move right
//                     ChangeSprite(rightSprites[spriteIndex]);
//                 }

//                 // Increment the sprite index for the next iteration
//                 spriteIndex = (spriteIndex + 1) % 2;
//             }
//         }
//     }

//     void ChangeSprite(Sprite newSprite)
//     {
//         spriteRenderer.sprite = newSprite;
//     }
// }


// TEST
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpriteChanger : MonoBehaviour
// {
//     public SpriteRenderer spriteRenderer;
//     public Sprite[] upSprites;
//     public Sprite[] leftSprites;
//     public Sprite[] downSprites;
//     public Sprite[] rightSprites;
//     public Sprite[] upHoldingSprites;
//     public Sprite[] leftHoldingSprites;
//     public Sprite[] downHoldingSprites;
//     public Sprite[] rightHoldingSprites;

//     public float spriteChangeInterval = 0.2f; // Time interval between sprite changes
//     private bool isWalking = false; // Indicates whether the character is walking
//     private bool isHoldingItem = false; // Indicates whether the character is holding an item
//     private float timeSinceLastSpriteChange = 0f; // Time elapsed since the last sprite change
//     private int spriteIndex = 0; // Index to keep track of the current sprite

//     void Start()
//     {
//         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
//     }

//     void Update()
//     {
//         // Check if any movement keys are pressed
//         bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

//         if (isMoving && !isWalking)
//         {
//             // Start walking animation
//             isWalking = true;
//             spriteIndex = 0;
//             timeSinceLastSpriteChange = 0f;
//         }
//         else if (!isMoving && isWalking)
//         {
//             // Stop walking animation
//             isWalking = false;
//             ChangeSprite(null); // Set the default sprite when not walking
//         }

//         // Check if the player is holding an item
//         isHoldingItem = GetComponentInChildren<PickUpPoint>() != null;

//         if (isWalking)
//         {
//             // Increment the time since the last sprite change
//             timeSinceLastSpriteChange += Time.deltaTime;

//             // Determine the sprite arrays based on the holding state
//             Sprite[] currentSprites;
//             if (isHoldingItem)
//             {
//                 currentSprites = GetSpritesByDirectionAndState(upHoldingSprites, leftHoldingSprites, downHoldingSprites, rightHoldingSprites);
//             }
//             else
//             {
//                 currentSprites = GetSpritesByDirectionAndState(upSprites, leftSprites, downSprites, rightSprites);
//             }

//             // Check if it's time to change the sprite
//             if (timeSinceLastSpriteChange >= spriteChangeInterval)
//             {
//                 timeSinceLastSpriteChange = 0f;

//                 // Change the sprite based on the current direction and holding state
//                 ChangeSprite(currentSprites[spriteIndex]);

//                 // Increment the sprite index for the next iteration
//                 spriteIndex = (spriteIndex + 1) % 2;
//             }
//         }
//     }

//     void ChangeSprite(Sprite newSprite)
//     {
//         spriteRenderer.sprite = newSprite;
//     }

//     Sprite[] GetSpritesByDirectionAndState(Sprite[] up, Sprite[] left, Sprite[] down, Sprite[] right)
//     {
//         if (Input.GetKey(KeyCode.W))
//         {
//             return up;
//         }
//         else if (Input.GetKey(KeyCode.A))
//         {
//             return left;
//         }
//         else if (Input.GetKey(KeyCode.S))
//         {
//             return down;
//         }
//         else if (Input.GetKey(KeyCode.D))
//         {
//             return right;
//         }

//         return null;
//     }
// }
