using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTrash : MonoBehaviour
{
    public Transform TrashParent;
    public float pickupDistance = 2f;
    public KeyCode pickupDropKey = KeyCode.F;

    private bool isEquipped = false;
    private Vector3 initialOffset;
    private Quaternion initialRotation;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (isEquipped && Input.GetKeyDown(pickupDropKey))
        {
            Drop();
        }
        else if (!isEquipped && Input.GetKeyDown(pickupDropKey))
        {
            TryEquip();
        }

        if (isEquipped)
        {
            UpdatePosition();
        }
    }

    void Drop()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<MeshCollider>().enabled = true;
        isEquipped = false;
    }

    void TryEquip()
    {
        if (Vector3.Distance(transform.position, TrashParent.position) <= pickupDistance)
        {
            Equip();
        }
    }

    void Equip()
    {
        initialOffset = transform.position - TrashParent.position;
        initialRotation = transform.rotation;

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<MeshCollider>().enabled = false;
        transform.SetParent(TrashParent);
        isEquipped = true;
    }

    void UpdatePosition()
    {
        transform.position = TrashParent.position + initialOffset;
        transform.rotation = initialRotation;
    }
}
