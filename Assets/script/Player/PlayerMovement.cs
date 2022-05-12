using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    protected PlayerAttack playerAttack;

    protected Effect effect;

    float lastAttackTime, lastDashTime;

    // h : horizontal 가로 방향
    // v : Vertical 세로 방향

    float h, v;

    public bool attacking = false;
    public bool dashing = false;

    private void Start()
    {
        avatar = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        // 게임 오브젝트 effect를 찾고 그 안에 effect 스크립트를 참3
        effect = GameObject.Find("Effect").GetComponent<Effect>();
    }

    public void onStickChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    private void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (avatar)
        {
            avatar.SetFloat("Speed", (h * h + v * v));

            Rigidbody rigidbody = GetComponent<Rigidbody>();

            if (rigidbody)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;

                if (h != 0f && v != 0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
                }
            }
        }
    }

    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());
    }

    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
        //Destroy(NormalHit, 2.0f);
    }

    IEnumerator StartAttack()
    {
        if (Time.time - lastAttackTime > 1f)
        {
            lastAttackTime = Time.time; // 선언된 시점부터 시간 계산
            while (attacking)
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack();
                effect.Normal_effect();
                //Instantiate(NormalHit, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void OnDashDown()
    {
        
        if (Time.time - lastDashTime > 3.0f)
        {
            dashing = true;
            lastDashTime = Time.time;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack();
            effect.dashing_Effect();
        }
    }

    public void OnDashUp()
    {
        dashing = false;
    }

    public void OnHomeDown()
    {
        SceneManager.LoadScene("Lobby");
    }
}
