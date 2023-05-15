using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float pickupDistance = 2f;

    private bool carryingObject = false;
    private GameObject carriedObject;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Object Interaction
        if (Input.GetMouseButtonDown(0))
        {
            if (!carryingObject)
                TryPickupObject();
            else
                TryDropObject();
        }
    }

    private void TryPickupObject()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                carryingObject = true;
                carriedObject = hit.collider.gameObject;
                carriedObject.transform.SetParent(transform, true); // Parenting the object to the player
                carriedObject.transform.localPosition = Vector3.zero;
                carriedObject.transform.localRotation = Quaternion.identity;
                carriedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }


    private void TryDropObject()
    {
        carryingObject = false;
        carriedObject.transform.SetParent(null);
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
