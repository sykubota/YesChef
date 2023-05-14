using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPickUpScript : MonoBehaviour
{

    public float speed;
    public float pickupDistance;

    // This variable will store the object that the player is currently holding.
    private GameObject heldObject;

    // This method will be called when the player presses the "Mouse0" key.
    void OnKeyDown(KeyCode key)
    {
        if (key == KeyCode.Mouse0)
        {
            // Get the collider that the player is colliding with.
            Collider collider = GetComponentInChildren<Collider>();

            // If the player is colliding with an object that has the "Pickable" tag and the player is close enough to the object, then pick it up.
            if (collider != null && collider.gameObject.tag == "Pickable" && (collider.gameObject.transform.position - transform.position).sqrMagnitude < pickupDistance * pickupDistance)
            {
                heldObject = collider.gameObject;
                collider.gameObject.transform.parent = transform;
            }
        }
    }

    // This method will be called when the player releases the "Mouse0" key.
    void OnKeyUp(KeyCode key)
    {
        if (key == KeyCode.Mouse0)
        {
            // If the player is holding an object, then drop it.
            if (heldObject != null)
            {
                heldObject.transform.parent = null;
                heldObject = null;
            }
        }
    }
}
