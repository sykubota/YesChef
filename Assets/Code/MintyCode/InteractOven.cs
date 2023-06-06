using UnityEngine;

public class InteractOven : MonoBehaviour
{
    public AudioSource audioSource;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public float interactionDistance = 2f;
    private Sprite previousSprite;
    public Oven oven;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            if (newSprite != null)
            {
                previousSprite = spriteRenderer.sprite; // Store the previous sprite
                spriteRenderer.sprite = newSprite; // Change the sprite
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (previousSprite != null)
            {
                bool value = oven.cooking;
                if (value==false)
                {
                    spriteRenderer.sprite = previousSprite; // Revert back to the previous sprite
                    previousSprite = null; // Reset the previous sprite
                }
            }
        }
    }
}
