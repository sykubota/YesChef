using UnityEngine;

public class SinkEffect : MonoBehaviour
{
    public GameObject Box;
    public float dropOffDistance = 3f;
    public Transform dropOffPoint; // Reference to the drop-off point on top of the sink

    private bool isBoxDroppedOff = false;
    private Transform player;
    private BoxMovement boxMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boxMovement = Box.GetComponent<BoxMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Box)
        {
            if (isBoxDroppedOff) // Check if the box has been dropped off
            {
                boxMovement.enabled = false; // Disable BoxMovement script
                Box.transform.position = dropOffPoint.position;
                Box.transform.rotation = dropOffPoint.rotation;
                Box.transform.SetParent(dropOffPoint);
                Box.GetComponent<Rigidbody>().isKinematic = true; // Make the box kinematic
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Box)
        {
            if (isBoxDroppedOff) // Check if the box has been dropped off
            {
                boxMovement.enabled = true; // Enable BoxMovement script
                Box.GetComponent<Rigidbody>().isKinematic = false; // Make the box non-kinematic
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isBoxDroppedOff && Vector3.Distance(player.position, transform.position) <= dropOffDistance)
        {
            DropBoxOff();
        }
    }

    public void DropBoxOff()
    {
        isBoxDroppedOff = true;
        boxMovement.enabled = false; // Disable BoxMovement script
        Box.transform.position = dropOffPoint.position;
        Box.transform.rotation = dropOffPoint.rotation;
        Box.transform.SetParent(dropOffPoint);
        Box.GetComponent<Rigidbody>().isKinematic = true; // Make the box kinematic
    }

    public void PickUpBox()
    {
        isBoxDroppedOff = false;
        boxMovement.enabled = true; // Enable BoxMovement script
        Box.transform.SetParent(null);
        Box.GetComponent<Rigidbody>().isKinematic = false; // Make the box non-kinematic
    }
}
