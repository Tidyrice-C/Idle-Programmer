using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class THREE : MonoBehaviour
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

    private readonly float basePrice = 8640.00f;
    private readonly float levelOneTimeModifier = 1 / 120f;
    private readonly float priceIncreaseModifier = 1.13f;
    private readonly float profitPerUnit = 4230;

    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public double timeWhenStart;
    [HideInInspector] public int level;

    // Start is called before the first frame update
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();

        if (SaveTimer.saveData == null)
        {
            level = 0;
        }
        else
        {
            level = SaveTimer.saveData.levelThree;
            isRunning = SaveTimer.saveData.isRunningThree;
            timeWhenStart = SaveTimer.saveData.timeWhenStartThree;
        }

        if (level == 0)
            gameObject.GetComponent<Button>().interactable = false;

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
        timeModifier = levelOneTimeModifier * Mathf.Pow(2, timesExecuted);

        //upgrade price text
        upgradePrice = basePrice * System.Math.Pow(priceIncreaseModifier, level);
        levelText.text = (level.ToString());

        if (level < 10000 && upgradePrice <= 9999999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 10000 && upgradePrice > 9999999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 10000
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max Level";
        }

        if (profitPerUnit * level < 999999999.99)
            profitText.text = $"{profitPerUnit * level:C}";
        else
            profitText.text = $"${profitPerUnit * level:E}";
    }

    void Update()
    {
        if (money.money >= upgradePrice)
            upgradeButton.interactable = true;
        else
            upgradeButton.interactable = false;

        if (level == 0)
            return;

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
            money.money += profitPerUnit * level;
        }

        else if (slider.value < slider.maxValue)
            slider.value = (float)(timeDifference * timeModifier);

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

        if (money.money - (basePrice * System.Math.Pow(priceIncreaseModifier, level)) < 0)
            return;

        money.money -= (basePrice * System.Math.Pow(priceIncreaseModifier, level));
        level++;

        if (level == 1)
            gameObject.GetComponent<Button>().interactable = true;

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
        timeModifier = levelOneTimeModifier * Mathf.Pow(2, timesExecuted);

        upgradePrice = basePrice * System.Math.Pow(priceIncreaseModifier, level);
        levelText.text = (level.ToString());

        if (level < 10000 && upgradePrice <= 9999999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 10000 && upgradePrice > 9999999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 10000
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max Level";
        }

        if (profitPerUnit * level < 999999999.99)
            profitText.text = $"{profitPerUnit * level:C}";
        else
            profitText.text = $"${profitPerUnit * level:E}";
    }

}
