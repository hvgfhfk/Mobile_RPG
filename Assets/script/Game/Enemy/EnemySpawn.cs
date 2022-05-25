using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    //public List<GameObject> enemy = new List<GameObject>();
    public static EnemySpawn instance;

    public float intervalTime = 10f;
    public Transform[] spawnPools;

    private void Awake()
    {
        EnemySpawn.instance = this;
    }

    private void Start()
    {
        InvokeRepeating("Spawn", intervalTime, intervalTime);
    }

    void Spawn()
    {
        int spawnPoolInbox = Random.Range(0, spawnPools.Length);
        Instantiate(enemy, spawnPools[spawnPoolInbox].position, spawnPools[spawnPoolInbox].rotation);
    }

    public void StopSpawn()
    {
        if(GameManager.instance.DeadCount >= GameManager.instance.MonsterMaxDead)
        {
            CancelInvoke("Spawn");
            GameManager.instance.MaxMonsterDead();
        }
    }
}
