using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject upgradewindow;

    public void MoveGameScene()
    {
        LoadSceneController.LoadScene("SampleScene");
    }

    public void UpgradeExit()
    {
        upgradewindow.SetActive(false);
    }
    public void UpgradeOpen()
    {
        upgradewindow.SetActive(true);
    }
}
