using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject platePrefab;  // The prefab object to spawn
    public Transform[] plateSpawnPoints;  // Array of spawn point transforms

    public void SpawnPlate()
    {
        if (platePrefab == null)
        {
            Debug.LogWarning("Prefab is not assigned!");
            return;
        }

        foreach (Transform plateSpawnPoint in plateSpawnPoints)
        {
            Collider[] colliders = Physics.OverlapSphere(plateSpawnPoint.position, 0.1f);

            if (colliders.Length == 0)
            {
                Instantiate(platePrefab, plateSpawnPoint.position, plateSpawnPoint.rotation);
                return;
            }
        }

        Debug.LogWarning("No available spawn points!");
    }
}
