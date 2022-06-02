using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Text text;
    public GameObject Shortage;
    

    private void Awake()
    {
        UIFade.instance = this;
        text = GetComponent<Text>();
    }

    public IEnumerator FadeIn()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.1f);
            text.color = new Color(255, 0, 0, fadeCount);
        }
        Shortage.SetActive(false);
        text.color = new Color(255, 0, 0, 255);
    }

}
