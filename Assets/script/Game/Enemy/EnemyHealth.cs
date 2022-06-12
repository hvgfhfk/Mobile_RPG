using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private EnemyCurrent enemyCurrent;
    [SerializeField]
    private UI uiCurrent;
    // 데미지 텍스트 표시를 위한 오브젝트 추가
    public GameObject hudDamageText;
    public Transform hudPos;
    // 아이템 프리팹
    public GameObject itemPrefab;

    // 컴포넌트
   // Animator m_anim;
    PlayerHealth playerHealth;

    private void Awake()
    {
        uiCurrent = GameObject.Find("Manager").GetComponent<UI>();
        enemyCurrent.CurrentHealth = enemyCurrent.StartingHealth;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        
    }

    public void TakeDamage(int amount)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = amount;

        enemyCurrent.m_anim.SetTrigger("isGetHit");

        enemyCurrent.CurrentHealth -= amount;

        // 몬스터 죽음 
        if (enemyCurrent.CurrentHealth <= 0 && !enemyCurrent.isDead)
        {
            Death();
        }
    }

    public IEnumerator StartDamage(int damage, Vector3 playerPosition, float delay, float pushBack) 
    {
        yield return new WaitForSeconds(delay);
        {
            try
            {
                TakeDamage(damage);
                Vector3 diff = playerPosition - transform.position;
                diff = diff / diff.sqrMagnitude;
                GetComponent<Rigidbody>().AddForce((transform.position - new Vector3(diff.x, diff.y, 0f)) * 50f * pushBack);
            } catch(MissingReferenceException e)
            {
                Debug.Log(e.ToString());
            }
        }
    }
    void Death()
    {
        enemyCurrent.isDead = true;
        uiCurrent.killCount += 1; // 킬 카운트 증가
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<SphereCollider>().enabled = false;

        // 몬스터가 죽었을 경우 플레이어의 체력 회복
        playerHealth.recovery_strength();
        Destroy(gameObject);

        // 경험치 증가
        GameManager.instance.GetExp(10);
        MonsterDropItem(); // 몬스터 아이템 드랍

        MaxKillCount();
    }

    void MonsterDropItem()
    {
        var Diamond = Instantiate<GameObject>(this.itemPrefab);
        Diamond.transform.position = this.gameObject.transform.position;
        Diamond.SetActive(true);
    }

    private void MaxKillCount()
    {
        if (uiCurrent.killCount == uiCurrent.MonsterMaxDead)
        {
            EnemySpawn.instance.SenceMoveNext();
            
        }
    }
}