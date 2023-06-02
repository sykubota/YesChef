using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item item;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (item != null && item.icon != null)
        {
            spriteRenderer.sprite = item.icon;
        }
    }

    //Other methods and functionality for the ItemHolder script
}
