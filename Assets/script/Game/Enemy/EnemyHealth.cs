using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    // 변수
    public int startingHealth = 100;
    public float sinkSpeed = 1f;
    public int currentHealth;
    public bool isDead;
    bool isSinking;

    // 데미지 텍스트 표시를 위한 오브젝트 추가
    public GameObject hudDamageText;
    public Transform hudPos;
    public GameObject itemPrefab;

    // 컴포넌트
    Animator m_anim;
    PlayerHealth playerHealth;


    private void Awake()
    {
        currentHealth = startingHealth;
       m_anim = GetComponent<Animator>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public void TakeDamage(int amount)
    {

        m_anim.SetTrigger("isGetHit");

        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<DamageText>().damage = amount;

        currentHealth -= amount;

        // 몬스터 죽음 
        if (currentHealth <= 0 && !isDead)
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

    private void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    void Death()
    {
        isDead = true;

        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<SphereCollider>().enabled = false;

        // 몬스터가 죽었을 경우 플레이어의 체력 회복
        playerHealth.recovery_strength();
        Destroy(gameObject);
        DropItem();
      //  this.onDie();
        GameManager.instance.GetExp(10);
    }

    void DropItem()
    {
        var Diamond = Instantiate<GameObject>(this.itemPrefab);
        Diamond.transform.position = this.gameObject.transform.position;
     //   Diamond.SetActive(false);
        Diamond.SetActive(true);
    }
}