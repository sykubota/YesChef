using UnityEngine;

public class PlatePickup : MonoBehaviour
{
    public Transform plateParent;
    public Collider ovenCollider;
    public AudioClip plateDroppedClip; // Reference to the audio clip
    public AudioSource soundPlayer;

    [HideInInspector]
    public bool isPlateEquipped = false;
    [HideInInspector]
    public Plate plate;
    public PlateSpawner plateSpawner;

    private void Start()
    {
        plate = GetComponentInChildren<Plate>();
        plateSpawner = FindObjectOfType<PlateSpawner>();

        if (plateParent == null)
        {
            // Find the "PickUpPoint" object under the character
            GameObject pickUpPointObject = GameObject.Find("Theo/PickUpPoint");
            if (pickUpPointObject != null)
            {
                plateParent = pickUpPointObject.transform;
            }
            else
            {
                Debug.LogWarning("PickUpPoint object not found!");
            }
        }

        if (ovenCollider == null)
        {
            // Find the "Oven" object in the scene
            GameObject ovenObject = GameObject.Find("Oven");
            if (ovenObject != null)
            {
                ovenCollider = ovenObject.GetComponent<Collider>();
            }
            else
            {
                Debug.LogWarning("Oven object not found!");
            }
        }
    }

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
            if (collider.gameObject != gameObject)
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
            soundPlayer.PlayOneShot(plateDroppedClip);
        }
    }

public void DropPlate()
{
    if (isPlateEquipped)
    {
        if (ovenCollider != null && ovenCollider.bounds.Contains(transform.position))
        {
            // Player is triggering the oven, do nothing
            return;
        }

        // Disable position freeze constraints
        Rigidbody plateRigidbody = plate.GetComponent<Rigidbody>();
        plateRigidbody.constraints = RigidbodyConstraints.None;

            Collider[] colliders = plate.GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }

        plate.transform.SetParent(null);
        plateSpawner.SpawnPlate();
        isPlateEquipped = false;
    }
}
}
