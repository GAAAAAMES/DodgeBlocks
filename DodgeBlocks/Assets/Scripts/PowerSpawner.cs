using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] powerUpPrefab;
    public static float timeToSpawnPower = 0;

    private void Start()
    {
        timeToSpawnPower = Random.Range(2, 4);
        timeToSpawnPower = timeToSpawnPower * 3 + 2;
    }

    void Update()
    {
        timeToSpawnPower -= Time.deltaTime;
        if(timeToSpawnPower<=0)
        {
            SpawnPower();
            timeToSpawnPower = Random.Range(2, 4)*3+2;
        }
    }

    void SpawnPower()
    {

        int randomIndex = Random.Range(0, spawnPoints.Length);
        int randomPower = Random.Range(0, powerUpPrefab.Length);
        Instantiate(powerUpPrefab[randomPower], spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
