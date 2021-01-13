using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{

    private double money;
    private int levelOne;

    public SaveData (Money moneyClass, ONE one)
    {
        money = moneyClass.money;
        levelOne = one.level;
    }
}
