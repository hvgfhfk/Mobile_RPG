using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;

public class items : MonoBehaviour
{
    [SerializeField]
    private static int nowDiamond = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance.GetDiamond(100);
        }
    }
}
