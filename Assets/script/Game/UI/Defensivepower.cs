using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defensivepower : MonoBehaviour
{
    [SerializeField]
    Player playerCurrent;

    public int upgradeCount;

    private void Awake()
    {
        upgradeCount = PlayerPrefs.GetInt("DefensiveCount");
    }

    public void UpgradeDefnsivePower()
    {
        playerCurrent.startingHealth += 5;
        upgradeCount++;
        DataAutoSave();
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("DefensiveCount", upgradeCount);
        PlayerPrefs.SetInt("StartingHealth", playerCurrent.startingHealth);
    }
    
}
