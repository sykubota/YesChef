using UnityEngine;

public class PlatePickup : MonoBehaviour
{
    public Plate plate;
    public Transform plateParent;

    public bool isPlateEquipped = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlateEquipped)
            {
                DropPlate();
            }
            else if (plate != null && plate.IsCollidingWithPlayer())
            {
                PickUpPlate();
            }
        }
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
            plate.transform.SetParent(null);
            isPlateEquipped = false;
        }
    }
}
