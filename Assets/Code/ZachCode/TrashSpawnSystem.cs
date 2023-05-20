using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnSystem : MonoBehaviour
{

    public GameObject[] objects;

    public void Spawn()
    {
        int randomIndex = Random.Range(0, objects.Length);
        Vector3 randomPosition = transform.position;
        Instantiate(objects[randomIndex], randomPosition, Quaternion.identity);
    }
}