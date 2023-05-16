using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float conveyorSpeed = 1.0f;
    private Vector3 initialPosition;
    public float endPositionThreshold = 10.0f; // Adjust this value

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Move the conveyor belt to the right
        transform.Translate(Vector3.right * conveyorSpeed * Time.deltaTime);

        // Check if the conveyor belt has reached the end, then reset it
        if (transform.position.x >= endPositionThreshold)
        {
            // Reset the position to the initial position
            transform.position = initialPosition;
        }
    }
}
