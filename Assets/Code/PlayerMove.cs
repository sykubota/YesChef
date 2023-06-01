using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10.0f;

    private void Update()
    {
        // Get the player input.
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        // Move the player in the direction of the input.
        transform.Translate(new Vector3(verticalInput * speed, 0, horizontalInput * speed));
    }
}
