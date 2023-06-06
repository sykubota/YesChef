using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theocontroller : MonoBehaviour
{
    public float speed = 5.0f;
    public Plate plate; // Reference to the Plate script

    public AudioSource soundPlayer; // Reference to the AudioSource component
    public AudioClip movementSound; // Sound to play when the character moves

    // Start is called before the first frame update
    void Start()
    {
        plate = FindObjectOfType<Plate>(); // Find the Plate object in the scene
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            PlayMovementSound();
        }
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            PlayMovementSound();
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            PlayMovementSound();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            PlayMovementSound();
        }

        // Drop item on the plate
        if (Input.GetKeyDown(KeyCode.F) && plate.IsCollidingWithPlayer())
        {
            Item item = GetComponent<ItemHolder>()?.item;
            if (item != null)
            {
                plate.AddItem(item);
                GetComponent<ItemHolder>().item = null;
            }
        }
    }

    private void PlayMovementSound()
    {
        // Play the movement sound
        if (soundPlayer != null && movementSound != null)
        {
            if (!soundPlayer.isPlaying)
            {
                soundPlayer.PlayOneShot(movementSound);
            }
        }
        else
        {
            Debug.LogWarning("SoundPlayer AudioSource or AudioClip is not assigned!");
        }
    }
}
