using UnityEngine;

public class FurnaceDestroy : MonoBehaviour
{

    // The tag of the GameObjects to delete.
    public string tagToDelete;

    void OnCollisionEnter(Collision collision)
    {
        // If the GameObject that collided with this one has the tag to delete, delete it.
        if (collision.gameObject.tag == tagToDelete)
        {
            Destroy(collision.gameObject);
        }
    }
}