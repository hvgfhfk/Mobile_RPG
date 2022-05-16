using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class xmlLoad : MonoBehaviour
{
    private void Start()
    {
        LoadXml();
    }

    void LoadXml()
    {
        TextAsset textasset = (TextAsset)Resources.Load("Chearacter");
        Debug.Log(textasset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textasset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        foreach (XmlNode node in nodes)
        {
            Debug.Log("Lv :: " + node.SelectSingleNode("lv").InnerText);
            Debug.Log("Exp :: " + node.SelectSingleNode("Exp").InnerText);
            Debug.Log("Coin :: " + node.SelectSingleNode("Coin").InnerText);

        }
    }
}
