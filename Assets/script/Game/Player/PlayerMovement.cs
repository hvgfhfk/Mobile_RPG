using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Player playerCurrent;
    protected PlayerAttack playerAttack;

    float h, v;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void OnStickChanged(Vector2 stickPos)
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
        if (playerCurrent.anim)
        {
            playerCurrent.anim.SetFloat("Speed", (h * h + v * v));

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
        playerCurrent.isAttackStatus = true;
        playerCurrent.anim.SetBool("Combo", true);
        StartCoroutine(StartAttack());
    }

    public void OnAttackUp()
    {
        playerCurrent.anim.SetBool("Combo", false);
        playerCurrent.isAttackStatus = false;
        //Destroy(NormalHit, 2.0f);
    }

    IEnumerator StartAttack()
    {
        if (Time.time - playerCurrent.lastAttackTime > 1f)
        {
            playerCurrent.lastAttackTime = Time.time; // 선언된 시점부터 시간 계산
            while (playerCurrent.isAttackStatus)
            {
                playerCurrent.anim.SetTrigger("AttackStart");
                playerAttack.NormalAttack();
                playerCurrent.effect.Normal_Effect();
                //Instantiate(NormalHit, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void OnDashDown()
    {

        if (Time.time - playerCurrent.lastDashTime > 1f)
        {
            playerCurrent.isDashStatus = true;
            playerCurrent.lastDashTime = Time.time;
            playerCurrent.anim.SetTrigger("Dash");
            playerAttack.DashAttack();
            playerCurrent.effect.dashing_Effect();
        }
    }

    public void OnDashUp()
    {
        playerCurrent.isDashStatus = false;
    }

}
