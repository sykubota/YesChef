using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] upSprites;
    public Sprite[] leftSprites;
    public Sprite[] downSprites;
    public Sprite[] rightSprites;
    public Sprite[] upHoldingSprites;
    public Sprite[] leftHoldingSprites;
    public Sprite[] downHoldingSprites;
    public Sprite[] rightHoldingSprites;
    public Sprite[] upIdleSprites;
    public Sprite[] leftIdleSprites;
    public Sprite[] downIdleSprites;
    public Sprite[] rightIdleSprites;
    public float animationSpeed = 5f;

    private int spriteIndex = 0;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Determine the current sprites based on the direction and holding state
        Sprite[] currentSprites = GetSpritesByDirection(upSprites, leftSprites, downSprites, rightSprites);

        // If no direction keys are pressed, set the idle sprites
        if (currentSprites == null)
        {
            currentSprites = GetIdleSprites();
        }

        // Check if the character is holding an object
        bool isHolding = CheckHolding();

        // If holding an object, use the holding sprites
        if (isHolding)
        {
            Sprite[] holdingSprites = GetSpritesByDirection(upHoldingSprites, leftHoldingSprites, downHoldingSprites, rightHoldingSprites);
            if (holdingSprites != null && holdingSprites.Length > 0)
            {
                currentSprites = holdingSprites;
            }
        }

        // Change the sprite based on the current sprites and sprite index
        if (currentSprites != null && currentSprites.Length > 0)
        {
            spriteIndex = Mathf.FloorToInt(Time.time * animationSpeed) % currentSprites.Length;
            ChangeSprite(currentSprites[spriteIndex]);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    Sprite[] GetSpritesByDirection(Sprite[] up, Sprite[] left, Sprite[] down, Sprite[] right)
    {
        if (Input.GetKey(KeyCode.W))
        {
            return up;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return right;
        }

        return null;
    }

    Sprite[] GetIdleSprites()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return upIdleSprites;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return leftIdleSprites;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return downIdleSprites;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return rightIdleSprites;
        }

        return null;
    }

    bool CheckHolding()
    {
        // Add your logic here to check if the character is holding an object
        // You can return true if the character is holding an object, false otherwise
        // For example:
        // return TrashEquip.IsHolding();

        return false;
    }
}
