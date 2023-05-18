using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTrash : MonoBehaviour
{
    public GameObject Trash;
    public Transform TrashParent;
    void Start()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Drop();
        } 
    }

    void Drop()
    {
        TrashParent.DetachChildren();
        Trash.transform.eulerAngles = new Vector3(Trash.transform.position.x, Trash.transform.position.z, Trash.transform.position.y);
        Trash.GetComponent<Rigidbody>().isKinematic = false;
        Trash.GetComponent<MeshCollider>().enabled = true;
    }

    void Equip()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = true;

        Trash.transform.position = TrashParent.transform.position;
        Trash.transform.position = TrashParent.transform.position;

        Trash.GetComponent<MeshCollider>().enabled = false;

        Trash.transform.SetParent(TrashParent);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Equip();
        }
    }
}
