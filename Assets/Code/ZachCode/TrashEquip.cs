using UnityEngine;

public class TrashEquip : MonoBehaviour
{
    public GameObject Trash;
    public Transform TrashParent;

    private void Start()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
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
        Trash.GetComponent<MeshCollider>().enabled = true;
    }

    void Equip()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = true;

        Trash.transform.position = TrashParent.transform.position;
        Trash.transform.rotation = TrashParent.transform.rotation;

        Trash.transform.SetParent(TrashParent);
        Trash.GetComponent<ConveyorBelt>().enabled = false;

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