using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    public Text diamond;
    public static LobbyButton instance;


    private void Awake()
    {
        CheckCanvasState();
        LobbyButton.instance = this;
        diamond.text = "100";
        
    }

    public void StartButtonOn()
    {
        SceneManager.LoadScene("SampleScene");
        GameObject.Find("Manager").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 0);
        GameObject.Find("Manager").transform.GetChild(1).gameObject.SetActive(false);
        //GameObject.Find("Canvas").SetActive(false);
    }

    void CheckCanvasState()
    {
        GameObject.Find("Manager").transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        GameObject.Find("Manager").transform.GetChild(1).gameObject.SetActive(true);
    }
}
