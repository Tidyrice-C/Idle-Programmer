using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public double money;

    public int levelOne;
    public bool isRunningOne;
    public double timeWhenStartOne;

    public SaveData (Money moneyClass, ONE one)
    {
        money = moneyClass.money;

        levelOne = one.level;
        isRunningOne = one.isRunning;
        timeWhenStartOne = one.timeWhenStart;
    }
}
