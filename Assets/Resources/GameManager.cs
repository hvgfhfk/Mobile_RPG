using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class GameManager : MonoBehaviour
{
    public float Exp;
    public float MaxExp = 100.0f;
    public int Lv;
    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
        LoadLvXml();
    }

    void LoadLvXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        // Lv = Convert.ToInt32(nodes.)

        foreach (XmlNode node in nodes)
        {

            Lv = Convert.ToInt32(node.SelectSingleNode("Level").InnerText);
            Exp = float.Parse(node.SelectSingleNode("Exp").InnerText);
        }
        Debug.Log("LoadLvXml : Lv : " + Lv);
        Debug.Log("LoadExpXml : Lv : " + Exp);
    }
}
