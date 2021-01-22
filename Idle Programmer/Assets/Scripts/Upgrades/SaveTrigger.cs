using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    public static UpgradeData upgradeData;

    private void Awake()
    {
        upgradeData = SSUpgrades.LoadData();
    }

    public static void OnPurchase(string ID)
    {
        NormalPurchase button = GameObject.Find(ID).GetComponentInChildren<NormalPurchase>();
    }
}
