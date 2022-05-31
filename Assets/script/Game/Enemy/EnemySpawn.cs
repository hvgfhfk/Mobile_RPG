using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy;
    //public List<GameObject> enemy = new List<GameObject>();
    public static EnemySpawn instance;

    [SerializeField]
    private float intervalTime = 10f;
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
        int MonsterSpawnNumber = Random.Range(0, enemy.Length); // �����Լ��� ����� ����
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
    { // �ش� ���Ͱ� ���������� ���Ͱ� �� �׾��� ��� ���������� �Ѿ��

        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync("Lobby");
    }
}
