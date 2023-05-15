using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public GameObject Box;
    public Transform PickupPlace;

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
    }

    void Equip()
    {
        Box.GetComponent<Rigidbody>().isKinematic = true;

        Box.transform.position = PickupPlace.transform.position;
        Box.transform.rotation = PickupPlace.transform.rotation;

        Box.GetComponent<MeshCollider>().enabled = false;

        Box.transform.SetParent(PickupPlace);

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