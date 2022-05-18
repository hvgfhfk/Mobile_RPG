using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    //public List<GameObject> enemy = new List<GameObject>();

    public float intervalTime = 10f;
    public Transform[] spawnPools;

    private void Start()
    {
        InvokeRepeating("Spawn", intervalTime, intervalTime);
    }

    void Spawn()
    {
        int spawnPoolInbox = Random.Range(0, spawnPools.Length);
        Instantiate(enemy, spawnPools[spawnPoolInbox].position, spawnPools[spawnPoolInbox].rotation);
    }
}
