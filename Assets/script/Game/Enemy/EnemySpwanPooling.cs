using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpwanPooling : MonoBehaviour
{
    public static EnemySpwanPooling instance;

    public GameObject[] monsterPrefab = null;

    public Queue<GameObject> monsterQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GameObject spawnPoolingManager = new GameObject("SpawnPooling");

        CreateNewObject(1);
    }
    void CreateNewObject(int count)
    {
        for (int i = 0; i < count; i++)
        { // 오브젝트 큐에 담을 오브젝트 (비활성)

            int randomCount = Random.Range(0, monsterPrefab.Length);

            GameObject target_object = Instantiate(monsterPrefab[randomCount], transform); // 오브젝트를 담을 위치
            monsterQueue.Enqueue(target_object);
            target_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject prefabObject)
    { // 대기열에 다시 넣기 
        monsterQueue.Enqueue(prefabObject);
        prefabObject.SetActive(false);
    }

    public GameObject GetQueue()
    { // 꺼내기

        if (monsterQueue.Count > 0)
        {
            GameObject targetObject = monsterQueue.Dequeue();
            targetObject.transform.SetParent(null); // 오브젝트를 꺼낼 위치 
            targetObject.SetActive(true);
            //gameObject.GetComponent<SphereCollider>().enabled = true;
            
            //GetComponent<SphereCollider>().enabled = true;
            
            return targetObject;
        }
        else
        { // 오브젝트가 부족하면 생성후 활성화

            int randomCount = Random.Range(0, 1);

            GameObject newObject = Instantiate(monsterPrefab[randomCount], transform);
            newObject.transform.SetParent(null);
            newObject.SetActive(true);

            return newObject;
        }

    }
}
