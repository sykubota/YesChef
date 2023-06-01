using UnityEngine;

public class PlatePickup : MonoBehaviour
{
    public Plate plate;
    public Transform plateParent;

    private bool isPlateEquipped = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isPlateEquipped)
            {
                DropPlate();
            }
            else
            {
                PickUpPlate();
            }
        }
    }

    private void PickUpPlate()
    {
        if (plate != null)
        {
            plate.transform.SetParent(plateParent);
            plate.transform.localPosition = Vector3.zero;
            plate.transform.localRotation = Quaternion.identity;
            plate.transform.Rotate(90, 0, 0);
            isPlateEquipped = true;
        }
    }

    private void DropPlate()
    {
        if (plate != null)
        {
            plate.transform.SetParent(null);
            isPlateEquipped = false;
        }
    }
}
