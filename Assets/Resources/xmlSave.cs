using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class xmlSave : MonoBehaviour
{
    private void Start()
    {
      //  SaveOverLapXml();
    }

    void SaveOverLapXml()
    {
       /* TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];

        character.SelectSingleNode("Level").InnerText = "5";
        character.SelectSingleNode("Exp").InnerText = "50";
        character.SelectSingleNode("coin").InnerText = "200";

        xmlDoc.Save("./Assets/Resources/Character.xml");*/
    }
}
