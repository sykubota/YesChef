using UnityEngine;

public class TrashEquip : MonoBehaviour
{
    public GameObject Trash;
    public Transform TrashParent;
    public bool isCarrying = false;
    private bool isTriggering = false;

    private void Start()
    {
        Trash.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCarrying)
            {
                Drop();
            }
            else if (isTriggering && !isCarrying) // Check if not carrying an item before equipping a new one
            {
                Equip();
            }
        }
    }

    void Equip()
    {
        if (!isCarrying)
        {
            Trash.GetComponent<Rigidbody>().isKinematic = true;
            Trash.transform.position = TrashParent.transform.position;
            Trash.transform.rotation = TrashParent.transform.rotation;
            Trash.transform.SetParent(TrashParent);
            Trash.GetComponent<ConveyorBelt>().enabled = false;
            Trash.GetComponent<BoxCollider>().enabled = true;
            isCarrying = true;
        }
    }

    void Drop()
    {
        if (isCarrying)
        {
            Trash.GetComponent<Rigidbody>().isKinematic = false;
            Trash.transform.SetParent(null);
            Trash.GetComponent<ConveyorBelt>().SetMoveState(false); // Stop the movement
            Trash.GetComponent<BoxCollider>().enabled = false;
            isCarrying = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggering = false;
        }
    }
}
