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

    public int levelTwo;
    public bool isRunningTwo;
    public double timeWhenStartTwo;
    public float timeModifierTwo;

    public int levelThree;
    public bool isRunningThree;
    public double timeWhenStartThree;
    public float timeModifierThree;

    public int levelFour;
    public bool isRunningFour;
    public double timeWhenStartFour;
    public float timeModifierFour;

    public SaveData (ONE one, TWO two, THREE three, FOUR four)
    {
        money = Money.money;

        levelOne = one.level;
        isRunningOne = one.isRunning;
        timeWhenStartOne = one.timeWhenStart;
        timeModifierOne = one.timeModifier;

        levelTwo = two.level;
        isRunningTwo = two.isRunning;
        timeWhenStartTwo = two.timeWhenStart;
        timeModifierTwo = two.timeModifier;

        levelThree = three.level;
        isRunningThree = three.isRunning;
        timeWhenStartThree = three.timeWhenStart;
        timeModifierThree = three.timeModifier;

        levelFour = four.level;
        isRunningFour = four.isRunning;
        timeWhenStartFour = four.timeWhenStart;
        timeModifierFour = four.timeModifier;

    }
}
