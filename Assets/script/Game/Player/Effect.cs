using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject NormalHit;
    public GameObject dashingHit;

    public void Normal_effect()
    {
        GameObject NormalHit_add = Instantiate(NormalHit, transform.position, Quaternion.identity);
        Destroy(NormalHit_add, 2.0f);
    }

    public void dashing_Effect()
    {
        GameObject dashing_add = Instantiate(dashingHit, transform.position, Quaternion.identity);
        Destroy(dashing_add, 2.0f);
    }
}
