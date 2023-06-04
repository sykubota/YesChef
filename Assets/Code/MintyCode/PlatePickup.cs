using UnityEngine;

public class PlatePickup : MonoBehaviour
{
    public GameObject[] plateObjects;
    public Transform plateParent;
    public Collider ovenCollider;

    private Plate currentPlate;
    public bool isPlateEquipped = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlateEquipped)
            {
                DropPlate();
            }
            else if (currentPlate != null && currentPlate.IsCollidingWithPlayer() && !IsItemAtPickupPoint())
            {
                PickUpPlate();
            }
        }
    }

    private bool IsItemAtPickupPoint()
    {
        Collider[] colliders = Physics.OverlapSphere(plateParent.position, 0.1f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != currentPlate.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    public void PickUpPlate()
    {
        if (!isPlateEquipped)
        {
            currentPlate.transform.SetParent(plateParent);
            currentPlate.transform.localPosition = Vector3.zero;
            currentPlate.transform.localRotation = Quaternion.identity;
            currentPlate.transform.Rotate(90, -90, 0);
            isPlateEquipped = true;
        }
    }

    public void DropPlate()
    {
        if (isPlateEquipped)
        {
            if (ovenCollider != null && ovenCollider.bounds.Contains(currentPlate.transform.position))
            {
                // Player is triggering the oven, do nothing
                return;
            }

            currentPlate.transform.SetParent(null);
            isPlateEquipped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject plateObject in plateObjects)
        {
            if (other.gameObject == plateObject)
            {
                currentPlate = other.gameObject.GetComponent<Plate>();
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject plateObject in plateObjects)
        {
            if (other.gameObject == plateObject)
            {
                currentPlate = null;
                break;
            }
        }
    }
}
