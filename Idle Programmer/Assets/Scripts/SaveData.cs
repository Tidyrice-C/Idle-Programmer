[System.Serializable]
public class SaveData
{
    public double money;

    public int levelOne;
    public double timeWhenStartOne;
    public float timeModifierOne;
    public float profitModifierOne;
    public bool automatedOne;

    public int levelTwo;
    public double timeWhenStartTwo;
    public float timeModifierTwo;
    public float profitModifierTwo;
    public bool automatedTwo;

    public int levelThree;
    public double timeWhenStartThree;
    public float timeModifierThree;
    public float profitModifierThree;
    public bool automatedThree;

    public int levelFour;
    public double timeWhenStartFour;
    public float timeModifierFour;
    public float profitModifierFour;
    public bool automatedFour;

    public SaveData ()
    {
        money = Money.money;

        levelOne = ONE.level;
        timeWhenStartOne = ONE.timeWhenStart;
        timeModifierOne = ONE.timeModifier;
        profitModifierOne = ONE.profitModifier;
        automatedOne = ONE.automated;

        levelTwo = TWO.level;
        timeWhenStartTwo = TWO.timeWhenStart;
        timeModifierTwo = TWO.timeModifier;
        profitModifierTwo = TWO.profitModifier;
        automatedTwo = TWO.automated;

        levelThree = THREE.level;
        timeWhenStartThree = THREE.timeWhenStart;
        timeModifierThree = THREE.timeModifier;
        profitModifierThree = THREE.profitModifier;
        automatedThree = THREE.automated;

        levelFour = FOUR.level;
        timeWhenStartFour = FOUR.timeWhenStart;
        timeModifierFour = FOUR.timeModifier;
        profitModifierFour = FOUR.profitModifier;
        automatedFour = FOUR.automated;

    }
}
