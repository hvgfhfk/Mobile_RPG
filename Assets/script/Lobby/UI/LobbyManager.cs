using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject upgradeWindow;

    public void MoveGameScene()
    {
        LoadSceneController.LoadScene("SampleScene");
    }

    public void UpgradeExit()
    {
        upgradeWindow.SetActive(false);
    }
    public void UpgradeOpen()
    {
        upgradeWindow.SetActive(true);
    }
}
