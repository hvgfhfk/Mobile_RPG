using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class xmlLoad : MonoBehaviour
{
    public Slider expslider;

    public Text Diamond;
    public Text Exp;
    public Text Level;

    private void Awake()
    {
        Diamond = GameObject.Find("DiamondCount").GetComponent<Text>();
        Exp = GameObject.Find("TextExp").GetComponent<Text>();
        Level = GameObject.Find("TextLevel").GetComponent<Text>();
        //Diamond = GetComponent<Text>();
        // Exp = GetComponent<Text>();

        LoadXml();
    }


    void LoadXml()
    {
        TextAsset textasset = (TextAsset)Resources.Load("Character");
       // Debug.Log(textasset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textasset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        foreach (XmlNode node in nodes)
        {
           // Debug.Log("Lv :: " + node.SelectSingleNode("Level").InnerText);
            Diamond.text = node.SelectSingleNode("coin").InnerText;
            Exp.text = node.SelectSingleNode("Exp").InnerText + " / 100";
            Level.text = "Lv : " + node.SelectSingleNode("Level").InnerText;
            expslider.value = float.Parse(node.SelectSingleNode("Exp").InnerText);
           // Debug.Log("Exp :: " + node.SelectSingleNode("Exp").InnerText);
           // Debug.Log("Coin :: " + node.SelectSingleNode("coin").InnerText);

        }
    }
}
