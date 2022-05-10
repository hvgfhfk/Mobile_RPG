using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // public PlayerMovement playermovement;
    public GameObject playermovement;

    public GameObject NormalHit;
    public GameObject dashingHit;

    bool attacking;
    bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        playermovement = GameObject.Find("Player") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Normal_Effect());
        StartCoroutine(dashing_Effect());
    }

    IEnumerator Normal_Effect()
    {
        attacking_checkState();
        // 일반 공격 이펙트 attacking_checkstate()
        if (attacking)
        {
            GameObject NormalHit_add = Instantiate(NormalHit, transform.position, Quaternion.identity);
            Destroy(NormalHit_add, 2.0f);

            yield return new WaitForSeconds(0.5f);
            attacking = false;
        }
    }

    IEnumerator dashing_Effect()
    {
        dashing_checkState();
        // 대쉬 공격 이펙트 dashing_checkstate()
        if(dashing)
        {
            GameObject dashing_add = Instantiate(dashingHit, transform.position, Quaternion.identity);
            Destroy(dashing_add, 2.0f);

            yield return new WaitForSeconds(0.5f);
            dashing = false;
        }
    }

    // 스크립트 변수 참조
    public void attacking_checkState()
    {
        if (playermovement.GetComponent<PlayerMovement>().attacking == true)
        {
            attacking = true;
        }
    }

    public void dashing_checkState()
    {
        if (playermovement.GetComponent<PlayerMovement>().dashing == true)
        {
            dashing = true;
        }
    }
}
