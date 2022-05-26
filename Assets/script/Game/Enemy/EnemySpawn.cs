using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy;
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
        int MonsterSpawnNumber = Random.Range(0, enemy.Length); // 랜덤함수에 사용할 변수
        Instantiate(enemy[MonsterSpawnNumber], spawnPools[spawnPoolInbox].position, spawnPools[spawnPoolInbox].rotation);
    }

    public void StopSpawn()
    {
        if(GameManager.instance.DeadCount >= GameManager.instance.MonsterMaxDead)
        {
            CancelInvoke("Spawn");
            StartCoroutine(nextSence());
        }
    }

    IEnumerator nextSence()
    { // 해당 몬스터가 스테이지의 몬스터가 다 죽었을 경우 다음씬으로 넘어가기

        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync("Lobby");
    }
}
