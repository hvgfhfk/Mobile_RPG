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

        LoadOverXml();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("아이템을 흭득했습니다.");

            Destroy(this.gameObject);
            getDia(100);
            SaveOverCoinCount();
        }
    }

    public void getDia(int newdia)
    {
        nowDiamond += newdia;
    }

    public void SaveOverCoinCount() // 세이브 xml
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];

        // character.SelectSingleNode("Exp").InnerText = "50";
        character.SelectSingleNode("coin").InnerText = Convert.ToString(nowDiamond); // 저장할 수치

        xmlDoc.Save("./Assets/Resources/Character.xml");

     //   Debug.Log("Save : " + nowDiamond);
    //    Debug.Log(character.SelectSingleNode("coin").InnerText);
    }

    public void LoadOverXml() // 로드 xml
    {
        TextAsset textasset = (TextAsset)Resources.Load("Character");
       // Debug.Log(textasset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textasset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        foreach (XmlNode node in nodes)
        {
            nowDiamond = Convert.ToInt32(node.SelectSingleNode("coin").InnerText);

           // Convert.ToString
      //      Debug.Log("LoadDiamond : " + nowDiamond);
            
        }
    }
}
