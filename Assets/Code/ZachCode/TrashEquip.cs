using UnityEngine;

public class TrashEquip : MonoBehaviour
{
    public GameObject Trash;
    public Transform TrashParent;

    private void Start()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = false;
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

        Trash.GetComponent<BoxCollider>().enabled = true;
    }




    void Equip()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = true;

        Trash.transform.position = TrashParent.transform.position;
        Trash.transform.rotation = TrashParent.transform.rotation;

        Trash.transform.SetParent(TrashParent);
        Trash.GetComponent<ConveyorBelt>().enabled = false;
        Trash.GetComponent<BoxCollider>().enabled = true;


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Trash.GetComponent<Rigidbody>().isKinematic = true;

            if (Input.GetKey(KeyCode.Space))
                {
                        Equip();
                    }
     
            }

        }
    }