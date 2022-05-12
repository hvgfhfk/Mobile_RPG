using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public int nowDiamond = 0;

    private void Awake()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("아이템을 흭득했습니다.");

            // LobbyButton.instance.getDiamond(100);
            Destroy(this.gameObject);
            getDia(100);
        }
    }

    public void getDia(int newdia)
    {
        nowDiamond = int.Parse(LobbyButton.instance.diamond.text);
        nowDiamond += newdia;
        LobbyButton.instance.diamond.text = nowDiamond.ToString();
    }
}
