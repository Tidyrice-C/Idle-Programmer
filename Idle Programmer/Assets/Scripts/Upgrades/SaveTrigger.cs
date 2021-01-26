using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour

    //YOULL HAVE TO MAKE PROFIT MODIFIER CALCULATE WHEN GAME IS LAUNCHED INSTEAD OF THROUGH JSON FILE TO AVOID TAMPERING CHENEY :)
{
    public static UpgradeData upgradeDataJSON;

    public static Dictionary<string, bool> upgradeData = new Dictionary<string, bool>();

    private void Awake()
    {
        GameObject[] normalUpgrades = GameObject.FindGameObjectsWithTag("NormalUpgrades");

        upgradeDataJSON = SSUpgrades.LoadData();

        if (upgradeDataJSON != null)
        {
            //INTERPRET EXISTING JSON FILE
            upgradeData["N1"] = upgradeDataJSON.N1;
            upgradeData["N2"] = upgradeDataJSON.N2;
        } 
        else
        {
            //GENERATE NEW FILE
            for (int i = 1; i <= normalUpgrades.Length; i++)
            {
                upgradeData["N"+i] = false;
            }

            SSUpgrades.SaveAll();
        }
    }

    public static void OnPurchase(string ID)
    {
        upgradeData[ID] = true;
        SSUpgrades.SaveAll();
        SaveSystem.SaveAll();
    }
}
