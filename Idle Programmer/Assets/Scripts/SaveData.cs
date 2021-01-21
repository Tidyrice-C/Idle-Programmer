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
    public float timeModifierOne;
    public float profitModifierOne;

    public int levelTwo;
    public bool isRunningTwo;
    public double timeWhenStartTwo;
    public float timeModifierTwo;
    public float profitModifierTwo;

    public int levelThree;
    public bool isRunningThree;
    public double timeWhenStartThree;
    public float timeModifierThree;
    public float profitModifierThree;

    public int levelFour;
    public bool isRunningFour;
    public double timeWhenStartFour;
    public float timeModifierFour;
    public float profitModifierFour;

    public SaveData ()
    {
        money = Money.money;

        levelOne = ONE.level;
        isRunningOne = ONE.isRunning;
        timeWhenStartOne = ONE.timeWhenStart;
        timeModifierOne = ONE.timeModifier;
        profitModifierOne = ONE.profitModifier;

        levelTwo = TWO.level;
        isRunningTwo = TWO.isRunning;
        timeWhenStartTwo = TWO.timeWhenStart;
        timeModifierTwo = TWO.timeModifier;

        levelThree = THREE.level;
        isRunningThree = THREE.isRunning;
        timeWhenStartThree = THREE.timeWhenStart;
        timeModifierThree = THREE.timeModifier;

        levelFour = FOUR.level;
        isRunningFour = FOUR.isRunning;
        timeWhenStartFour = FOUR.timeWhenStart;
        timeModifierFour = FOUR.timeModifier;

    }
}
