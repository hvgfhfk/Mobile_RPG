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
    PlayerHealth playerHealth;

    private void Awake()
    {
        uiCurrent = GameObject.Find("Manager").GetComponent<UI>();
        enemyCurrent.currentHealth = enemyCurrent.startingHealth;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        //StartCoroutine("StartDamage");
    }

    public void TakeDamage(int amount)
    {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = amount;

        enemyCurrent.anim.SetTrigger("isGetHit");

        enemyCurrent.currentHealth -= amount;

        // 몬스터 죽음 
        if (enemyCurrent.currentHealth <= 0 && !enemyCurrent.isDead)
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
        Dead();
        GetExp();
        MonsterDropItem(); // 몬스터 아이템 드랍
        CompletionMonsterKill();
        //EnemySpwanPooling.instance.InsertQueue(gameObject);
    }

    private void Dead() // * 
    { // 몬스터 죽음
        enemyCurrent.isDead = true;
        uiCurrent.killCount += 1;
        playerHealth.RecoveryStrength(); // 플레이어 체력 회복
        Destroy(gameObject);
    }

    private void GetExp()
    { // 경험치 흭득
        GameManager.instance.GetExp(enemyCurrent.monsterExp);
    }

    void MonsterDropItem()
    { // 아이템 드랍
        var diamond = Instantiate<GameObject>(this.itemPrefab);
        diamond.transform.position = this.gameObject.transform.position;
        diamond.SetActive(true);
    }

    private void CompletionMonsterKill()
    { // 최대 킬 완료
        if (uiCurrent.killCount == uiCurrent.monsterMaxDead)
        {
            EnemySpawn.instance.SenceMoveNext();
            
        }
    }
}