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

    public int levelTwo;
    public bool isRunningTwo;
    public double timeWhenStartTwo;

    public int levelThree;
    public bool isRunningThree;
    public double timeWhenStartThree;

    public SaveData (Money moneyClass, ONE one, TWO two, THREE three)
    {
        money = moneyClass.money;

        levelOne = one.level;
        isRunningOne = one.isRunning;
        timeWhenStartOne = one.timeWhenStart;

        levelTwo = two.level;
        isRunningTwo = two.isRunning;
        timeWhenStartTwo = two.timeWhenStart;

        levelThree = three.level;
        isRunningThree = three.isRunning;
        timeWhenStartThree = three.timeWhenStart;

    }
}
