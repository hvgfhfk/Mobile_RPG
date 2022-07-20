using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpwanPooling : MonoBehaviour
{
    public static EnemySpwanPooling instance;

    public GameObject[] MonsterPrefab = null;

    public Queue<GameObject> Monster_queue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GameObject SpawnPoolingManager = new GameObject("SpawnPooling");

        createNewObject(1);
    }
    void createNewObject(int Count)
    {
        for (int i = 0; i < Count; i++)
        { // 오브젝트 큐에 담을 오브젝트 (비활성)

            int randomCount = Random.Range(0, MonsterPrefab.Length);

            GameObject target_object = Instantiate(MonsterPrefab[randomCount], transform); // 오브젝트를 담을 위치
            Monster_queue.Enqueue(target_object);
            target_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject Prefab_object)
    { // 대기열에 다시 넣기 
        Monster_queue.Enqueue(Prefab_object);
        Prefab_object.SetActive(false);
    }

    public GameObject GetQueue()
    { // 꺼내기

        if (Monster_queue.Count > 0)
        {
            GameObject target_object = Monster_queue.Dequeue();
            target_object.transform.SetParent(null); // 오브젝트를 꺼낼 위치 
            target_object.SetActive(true);
            //gameObject.GetComponent<SphereCollider>().enabled = true;
            
            //GetComponent<SphereCollider>().enabled = true;
            
            return target_object;
        }
        else
        { // 오브젝트가 부족하면 생성후 활성화

            int randomCount = Random.Range(0, 1);

            GameObject newObject = Instantiate(MonsterPrefab[randomCount], transform);
            newObject.transform.SetParent(null);
            newObject.SetActive(true);

            return newObject;
        }

    }
}
