using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject upgradewindow;

    public void MoveGameScene()
    {
        SceneManager.LoadSceneAsync("SampleScene");
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
