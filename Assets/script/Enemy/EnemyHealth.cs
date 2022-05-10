using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // enemyhealth
    public int startingHealth = 100;
    public int currentHealth;

    private Animator m_anim;
    EnemyAttack enemyAttack;
   // public float flashSpeed = 5f;
   // public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
   

    public float sinkSpeed = 1f;

    public bool isDead;
    bool isSinking;
    bool damaged;

    private void Awake()
    {
        currentHealth = startingHealth;
        m_anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        m_anim.SetTrigger("isGetHit");
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
        damaged = false;
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    void Death()
    {
        isDead = true;
        //enemymove.nav.Stop();

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

        StartSinking();
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(GameObject.Find("Slime"), 2f);
    }
}
