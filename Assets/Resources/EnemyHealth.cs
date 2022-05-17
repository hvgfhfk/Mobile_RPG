using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // enemyhealth
    public int startingHealth = 100;
    public int currentHealth;

    private Animator m_anim;

    EnemyAttack enemyAttack;
    PlayerHealth playerHealth;

    // public float flashSpeed = 5f;
    // public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // 데미지 텍스트 표시를 위한 오브젝트 추가
    public GameObject hudDamageText;
    public Transform hudPos;

    public GameObject itemPrefab;

    public System.Action onDie;

    public float sinkSpeed = 1f;

    public bool isDead;
    bool isSinking;



    private void Awake()
    {
        currentHealth = startingHealth;
        m_anim = GetComponent<Animator>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
      //  LoadLvXml();
    }

    private void Start()
    {
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
        this.onDie();
        GetExpText(10.0f);
    }

    void DropItem()
    {
        var Diamond = Instantiate<GameObject>(this.itemPrefab);
        Diamond.transform.position = this.gameObject.transform.position;
        Diamond.SetActive(false);
        this.onDie = () =>
        {
            Diamond.SetActive(true);
        };
    }

    public void GetExpText(float PlayerGetExp)
    {
        if (GameManager.instance.Exp <= GameManager.instance.MaxExp)
        {
            GameManager.instance.Exp += PlayerGetExp;
            if (GameManager.instance.Exp >= GameManager.instance.MaxExp)
            {
                GameManager.instance.Exp = 0f;
                GameManager.instance.Lv += 1;
              //  SaveLvXml();
            }
            //   ExpText.text = Exp + " / " + MaxExp;

            Debug.Log("Now Lv : " + GameManager.instance.Lv);
            Debug.Log("Now Exp : " + GameManager.instance.Exp);

            SaveLvXml();
        } 
    }


    public void SaveLvXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];

        // character.SelectSingleNode("Exp").InnerText = "50";
        character.SelectSingleNode("Level").InnerText = Convert.ToString(GameManager.instance.Lv); // 저장할 수치
        character.SelectSingleNode("Exp").InnerText = Convert.ToString(GameManager.instance.Exp); // 저장할 수치

        xmlDoc.Save("./Assets/Resources/Character.xml");

        Debug.Log("SaveLvXml : Lv : " + GameManager.instance.Lv);
        Debug.Log("SaveExpXml : EXP : " + GameManager.instance.Exp);
    }
}