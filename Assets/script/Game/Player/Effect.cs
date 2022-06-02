using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    private Player playerCurrent;

    public void Normal_effect()
    {
        GameObject NormalHit_add = Instantiate(playerCurrent.NormalHit, transform.position, Quaternion.identity);
        Destroy(NormalHit_add, 2.0f);
    }

    public void dashing_Effect()
    {
        GameObject dashing_add = Instantiate(playerCurrent.dashingHit, transform.position, Quaternion.identity);
        Destroy(dashing_add, 2.0f);
    }
}
