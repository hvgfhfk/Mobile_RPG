using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class xmlSave : MonoBehaviour
{
    private void Start()
    {
        SaveOverLapXml();
    }

    void SaveOverLapXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("ChearacterInfo/Character");
        XmlNode character = nodes[0];

        character.SelectSingleNode("lv").InnerText = "5";
        character.SelectSingleNode("Exp").InnerText = "50";
        character.SelectSingleNode("Coin").InnerText = "200";

        xmlDoc.Save("./Character.xml");
    }
}
