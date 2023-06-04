using UnityEngine;

public class PlatePickup : MonoBehaviour
{
    public Plate plate;
    public Transform plateParent;
    public Collider ovenCollider;

    public bool isPlateEquipped = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlateEquipped)
            {
                DropPlate();
            }
            else if (plate != null && plate.IsCollidingWithPlayer() && !IsItemAtPickupPoint())
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
            if (collider.gameObject != plate.gameObject)
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
            plate.transform.SetParent(plateParent);
            plate.transform.localPosition = Vector3.zero;
            plate.transform.localRotation = Quaternion.identity;
            plate.transform.Rotate(90, -90, 0);
            isPlateEquipped = true;


        }
    }

    public void DropPlate()
    {
        if (isPlateEquipped)
        {
            if (ovenCollider != null && ovenCollider.bounds.Contains(plate.transform.position))
            {
                // Player is triggering the oven, do nothing
                return;
            }

            plate.transform.SetParent(null);
            isPlateEquipped = false;
        }
    }
}
