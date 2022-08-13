using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    private Player playerCurrent;

    public void Normal_Effect()
    {
        GameObject normalAdd = Instantiate(playerCurrent.normalHit, transform.position, Quaternion.identity);
        Destroy(normalAdd, 2.0f);
    }

    public void dashing_Effect()
    {
        GameObject dashingAdd = Instantiate(playerCurrent.dashingHit, transform.position, Quaternion.identity);
        Destroy(dashingAdd, 2.0f);
    }
}
