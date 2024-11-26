using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyToSpawn;

    public float spawnRate;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        InvokeRepeating("Spawn", 3f, spawnRate);
    }

    void Spawn()
    {
        Instantiate(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
    }
}
