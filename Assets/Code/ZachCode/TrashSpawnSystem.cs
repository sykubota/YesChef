using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnSystem : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public Transform[] spawnPoints;
    public Transform destinationPoint;
    public float spawnInterval = 1f;
    public float movementSpeed = 1f;

    private void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    IEnumerator SpawnTrash()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomValue = Random.value;
            if (randomValue <= 0.25f)
            {
                int randomIndex = Random.Range(0, trashPrefabs.Length);
                GameObject randomTrash = trashPrefabs[randomIndex];

                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomSpawnIndex];

                GameObject spawnedTrash = Instantiate(randomTrash, spawnPoint.position, Quaternion.identity);

                // Calculate the direction to the destination point
                Vector3 direction = (destinationPoint.position - spawnedTrash.transform.position).normalized;

                // Set the initial movement velocity
                Rigidbody trashRigidbody = spawnedTrash.GetComponent<Rigidbody>();
                if (trashRigidbody != null)
                {
                    trashRigidbody.velocity = direction * movementSpeed;
                }
            }
        }
    }
}
