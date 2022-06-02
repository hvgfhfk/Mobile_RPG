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
        if (playerCurrent.p_anim)
        {
            playerCurrent.p_anim.SetFloat("Speed", (h * h + v * v));

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
        playerCurrent.attacking = true;
        playerCurrent.p_anim.SetBool("Combo", true);
        StartCoroutine(StartAttack());
    }

    public void OnAttackUp()
    {
        playerCurrent.p_anim.SetBool("Combo", false);
        playerCurrent.attacking = false;
        //Destroy(NormalHit, 2.0f);
    }

    IEnumerator StartAttack()
    {
        if (Time.time - playerCurrent.LastAttackTime > 1f)
        {
            playerCurrent.LastAttackTime = Time.time; // 선언된 시점부터 시간 계산
            while (playerCurrent.attacking)
            {
                playerCurrent.p_anim.SetTrigger("AttackStart");
                playerAttack.NormalAttack();
                playerCurrent.effect.Normal_effect();
                //Instantiate(NormalHit, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void OnDashDown()
    {

        if (Time.time - playerCurrent.LastDashTime > 3.0f)
        {
            playerCurrent.dashing = true;
            playerCurrent.LastDashTime = Time.time;
            playerCurrent.p_anim.SetTrigger("Dash");
            playerAttack.DashAttack();
            playerCurrent.effect.dashing_Effect();
        }
    }

    public void OnDashUp()
    {
        playerCurrent.dashing = false;
    }

}
