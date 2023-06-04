using UnityEngine;

public class SpriteAppearOnPlate : MonoBehaviour
{

    // The tag of the GameObjects to delete.
    public string tagToDelete;

    void OnCollisionEnter(Collision collision)
    {
        // If the GameObject that collided with this one has the tag to delete, delete it.
        if (collision.gameObject.tag == tagToDelete && gameObject.name == "Chunky Milk")
        {
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().enabled = true;

        }
    }
}