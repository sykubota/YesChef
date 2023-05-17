using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public ConveyorBelt conveyorBelt; // Reference to the conveyor belt object
    public bool isPickedUp = false; // Flag to track if the box is picked up

    private void Update()
    {
        if (!isPickedUp)
        {
            // Move the box along with the conveyor belt
            transform.Translate(conveyorBelt.conveyorSpeed * Vector3.right * Time.deltaTime);
        }
    }

    public void SetPickedUp(bool pickedUp)
    {
        isPickedUp = pickedUp;
    }
}
