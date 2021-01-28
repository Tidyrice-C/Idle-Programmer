using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    public static UpgradeData upgradeDataJSON;

    public static Dictionary<string, bool> upgradeData = new Dictionary<string, bool>();

    private void Awake()
    {
        GameObject[] normalUpgrades = GameObject.FindGameObjectsWithTag("NormalUpgrades");

        upgradeDataJSON = SaveSystem.LoadUpgradeData();

        if (upgradeDataJSON != null)
        {
            //INTERPRET EXISTING JSON FILE
            upgradeData["N1"] = upgradeDataJSON.N1;
            upgradeData["N2"] = upgradeDataJSON.N2;

            //upgrade file integrity check
            if ((ONE.profitModifier != 1 && upgradeDataJSON.N1 == false) || (ONE.profitModifier == 1 && upgradeDataJSON.N1 == true))
            {
                GenerateFile(normalUpgrades);
            }
        } 
        else
        {
            GenerateFile(normalUpgrades);
        }
    }

    public static void OnPurchase(string ID)
    {
        upgradeData[ID] = true;
        SaveSystem.SaveAll();
        SaveSystem.SaveUpgrades();
    }

    private void GenerateFile(GameObject[] normalUpgrades)
    {
        //GENERATE NEW FILE
        for (int i = 1; i <= normalUpgrades.Length; i++)
        {
            upgradeData["N" + i] = false;
        }

        SaveSystem.ResetUpgrades();
        SaveSystem.SaveUpgrades();
    }
}
