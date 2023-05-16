using UnityEngine;

public class SinkEffect : MonoBehaviour
{
    public GameObject Box;
    public float dropOffDistance = 3f;

    private bool isMagnetActive = false;
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
            isMagnetActive = true;
            boxMovement.enabled = false; // Disable BoxMovement script
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Box)
        {
            isMagnetActive = false;
            boxMovement.enabled = true; // Enable BoxMovement script
        }
    }

    private void FixedUpdate()
    {
        if (isMagnetActive && Vector3.Distance(player.position, transform.position) <= dropOffDistance)
        {
            Box.GetComponent<Rigidbody>().isKinematic = true;
            Box.transform.position = transform.position;
        }
    }
}
