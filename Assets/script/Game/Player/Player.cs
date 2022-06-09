using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator p_anim;
    public Effect effect;
    public float LastAttackTime; // ??? ?? ??
    public float LastDashTime; // ??? ?? ?? ??
    public bool attacking = false; // ?? ??
    public bool dashing = false; // ?? ?? ??
    public GameObject NormalHit; // ?? ?? ???
    public GameObject dashingHit; // ?? ?? ???
    public bool isdead = false; // ?? ??
    public bool damaged; // ??? ???? ??(player)
    public int startingHealth;
}
