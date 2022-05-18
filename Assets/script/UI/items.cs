using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;

public class items : MonoBehaviour
{
    public static int nowDiamond = 0;

    public Text DiamondText;
    private void Awake()
    {
        DiamondText = GetComponent<Text>();
        nowDiamond = PlayerPrefs.GetInt("Diamond"); // 변수에 다이아 저장한거 불러오기

      //  LoadOverXml();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("아이템을 흭득했습니다.");

            Destroy(this.gameObject);
            getDia(100);

            PlayerPrefs.SetInt("Diamond", nowDiamond); // 다이아 코인 저장
        }
    }

    public void getDia(int newdia)
    {
        nowDiamond += newdia;
    }
}
