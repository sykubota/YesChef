using UnityEngine;

public class PlateSpawn : MonoBehaviour
{

    public GameObject prefab;

    private void OnDestroy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}