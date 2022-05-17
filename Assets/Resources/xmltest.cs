using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class xmltest : MonoBehaviour
{
    private void Start()
    {
        CreateXml();
    }

    void CreateXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        xmlDoc.AppendChild(root);

        // 자식 노드
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        root.AppendChild(child);

        // 자식 노드 속성 생성
        XmlElement lv = xmlDoc.CreateElement("Level");
        lv.InnerText = "1";
        child.AppendChild(lv);

        XmlElement exp = xmlDoc.CreateElement("Exp");
        exp.InnerText = "1";
        child.AppendChild(exp);

        XmlElement coin = xmlDoc.CreateElement("coin");
        coin.InnerText = "1";
        child.AppendChild(coin);

        xmlDoc.Save("./Assets/Resources/Character.xml");

    }
}
