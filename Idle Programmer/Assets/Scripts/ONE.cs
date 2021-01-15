using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ONE : MonoBehaviour
{
    public GameObject sliderObject;
    private Slider slider;

    public Button upgradeButton;

    public TMPro.TextMeshProUGUI levelText;
    public TMPro.TextMeshProUGUI upgradeText;
    public TMPro.TextMeshProUGUI timeText;
    public TMPro.TextMeshProUGUI profitText;

    public Money money;

    private double currentTime;
    private double upgradePrice;
    private double toComplete;

    private float timeModifier;

    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public double timeWhenStart;
    [HideInInspector] public int level;

    // Start is called before the first frame update
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();

        if (SaveTimer.saveData == null)
        {
            level = 1;
        }
        else
        {
            level = SaveTimer.saveData.levelOne;
            isRunning = SaveTimer.saveData.isRunningOne;
            timeWhenStart = SaveTimer.saveData.timeWhenStartOne;
        }

        //figuring out time modifier based on level
        int i = level;
        int timesExecuted = 0;
        while (i >= 1)
        {
            //first time, do this
            if (timesExecuted == 0)
            {
                i /= 25;
                timesExecuted++;
            }
            else
            {
                i /= 2;
                timesExecuted++;
            }
        }
            timesExecuted--;
        timeModifier = 0.05f * Mathf.Pow(2, timesExecuted);

        //upgrade price text
        upgradePrice = 3.69 * System.Math.Pow(1.07, level - 1);
        levelText.text = (level.ToString());

        if (level < 10000 && upgradePrice <= 9999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 10000 && upgradePrice > 9999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 10000
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max Level";
        }

        if (1 * level < 999999999.99)
            profitText.text = $"{1 * level:C}";
        else
            profitText.text = $"${1 * level:E}";
    }

    void Update()
    {
        Debug.Log(timeModifier);
        if (money.money >= upgradePrice)
            upgradeButton.interactable = true;
        else
            upgradeButton.interactable = false;

        if (!isRunning)
        {
            timeText.text = "00:00:00";
            slider.value = 0;
            return;
        }

        //else if ISRUNNING = true then DO THIS
        currentTime = CanvasTime.GetUnixTime();

        double timeDifference = currentTime - timeWhenStart;

        if (slider.value >= slider.maxValue)
        {
            isRunning = false;
            money.money += 1 * level;
        }

        else if (slider.value < slider.maxValue)
            slider.value = (float) (timeDifference * timeModifier);

        double timeRemaining = toComplete - currentTime;

        if (timeRemaining <= 0)
            return;

        string hours = System.Math.Floor(timeRemaining / 3600000).ToString();
        string minutes = System.Math.Floor(timeRemaining % 3600000 / 60000).ToString();
        string seconds = System.Math.Ceiling(timeRemaining % 3600000 % 60000 / 1000).ToString();
        timeText.text = $"{hours.PadLeft(2, '0')}:{minutes.PadLeft(2, '0')}:{seconds.PadLeft(2, '0')}";
    }

    //executes when image is clicked
    public void onClick()
    {
        if (isRunning)
            return;
        //else
        isRunning = true;
        timeWhenStart = CanvasTime.GetUnixTime();
        toComplete = timeWhenStart + 100 / timeModifier;
    }

    public void onBuy()
    {
        if (level >= 10000)
            return;

        if (money.money - (3.69 * System.Math.Pow(1.07, level - 1)) < 0)
            return;

        money.money -= (3.69 * System.Math.Pow(1.07, level - 1));
        level++;

        //figuring out time modifier based on level
        int i = level;
        int timesExecuted = 0;
        while (i >= 1)
        {
            //first time, do this
            if (timesExecuted == 0)
            {
                i /= 25;
                timesExecuted++;
            }
            else
            {
                i /= 2;
                timesExecuted++;
            }
        }
            timesExecuted--;
        timeModifier = 0.05f * Mathf.Pow(2, timesExecuted);

        upgradePrice = 3.69 * System.Math.Pow(1.07, level - 1);
        levelText.text = (level.ToString());

        if (level < 10000 && upgradePrice <= 9999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 10000 && upgradePrice > 9999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 10000
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max Level";
        }

        if (1 * level < 999999999.99)
            profitText.text = $"{1 * level:C}";
        else
            profitText.text = $"${1 * level:E}";
    }
    
}
