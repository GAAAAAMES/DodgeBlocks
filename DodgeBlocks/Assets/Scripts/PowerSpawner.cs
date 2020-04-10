using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] powerUpPrefab;
    private float timeToSpawn = 0;

    private void Start()
    {
        timeToSpawn = Random.Range(5f, 10f);
    }

    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn<=0)
        {
            SpawnPower();
            timeToSpawn = Random.Range(20f, 40f);
        }
    }

    void SpawnPower()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomPower = Random.Range(0, powerUpPrefab.Length);
        Instantiate(powerUpPrefab[randomPower], spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
