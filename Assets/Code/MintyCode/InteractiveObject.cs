using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public AudioSource audioSource;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public float interactionDistance = 2f;
    private Sprite previousSprite;

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
            // if (audioSource != null && audioSource.isPlaying)
            // {
            //     audioSource.Stop(); // Stop the audio if it's still playing
            // }

            if (previousSprite != null)
            {
                spriteRenderer.sprite = previousSprite; // Revert back to the previous sprite
                previousSprite = null; // Reset the previous sprite
            }
        }
    }
}
