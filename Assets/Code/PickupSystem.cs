using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public GameObject Box;
    public Transform PickupPlace;

    private BoxMovement boxMovement; // Reference to the BoxMovement script

    void Start()
    {
        Box.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Drop();
        }
    }

    void Drop()
    {
        PickupPlace.DetachChildren();
        Box.transform.eulerAngles = new Vector3(Box.transform.position.x, Box.transform.position.z, Box.transform.position.y);
        Box.GetComponent<Rigidbody>().isKinematic = false;
        Box.GetComponent<MeshCollider>().enabled = true;

        if (boxMovement != null)
        {
            boxMovement.SetPickedUp(false); // Set isPickedUp to false
        }
    }

    void Equip()
    {
        Box.GetComponent<Rigidbody>().isKinematic = true;

        Box.transform.position = PickupPlace.transform.position;
        Box.transform.rotation = PickupPlace.transform.rotation;

        Box.GetComponent<MeshCollider>().enabled = false;

        Box.transform.SetParent(PickupPlace);

        boxMovement = Box.GetComponent<BoxMovement>();

        if (boxMovement != null)
        {
            boxMovement.SetPickedUp(true); // Set isPickedUp to true
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Equip();
            }
        }
    }
}
