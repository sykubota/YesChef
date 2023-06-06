
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public AudioSource audioSource;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public float interactionDistance = 2f;


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
                spriteRenderer.sprite = newSprite;
            }
               
        }
    }
}
