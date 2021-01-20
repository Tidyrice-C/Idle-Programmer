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

    private double currentTime;
    private double upgradePrice;
    private double toComplete;

    private readonly float basePrice = 3.64f;
    private readonly float levelOneTimeModifier = 0.1f;
    private readonly float priceIncreaseModifier = 1.07f;
    private readonly float profitPerUnit = 1.00f;

    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public double timeWhenStart;
    [HideInInspector] public int level;
    [HideInInspector] public float timeModifier;

    // Start is called before the first frame update
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();

        if (SaveTimer.saveData == null)
        {
            level = 1;
            timeModifier = levelOneTimeModifier;
        }
        else
        {
            level = SaveTimer.saveData.levelOne;
            isRunning = SaveTimer.saveData.isRunningOne;
            timeWhenStart = SaveTimer.saveData.timeWhenStartOne;
            timeModifier = SaveTimer.saveData.timeModifierOne;
        }

        //figuring out time modifier based on level
        toComplete = timeWhenStart + 100 / timeModifier;

        //upgrade price text
        upgradePrice = basePrice * System.Math.Pow(priceIncreaseModifier, level);
        levelText.text = (level.ToString());

        if (level < 51200 && upgradePrice <= 999999999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 51200 && upgradePrice > 999999999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 51200
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max";
        }

        if (profitPerUnit * level < 999999999.99)
            profitText.text = $"{profitPerUnit * level:C}";
        else
            profitText.text = $"${profitPerUnit * level:E}";
    }

    void Update()
    {
        if (Money.money >= upgradePrice)
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
        currentTime = CanvasTime.unixTime;

        double timeDifference = currentTime - timeWhenStart;

        if (slider.value >= slider.maxValue)
        {
            isRunning = false;
            Money.money += profitPerUnit * level;
        }

        else if (slider.value < slider.maxValue)
            slider.value = (float) (timeDifference * timeModifier);

        double timeRemaining = toComplete - currentTime;

        //executes three times every second (60 frames = 1 second)
        if (timeRemaining > 0 && Time.frameCount % 10 == 0)
        {
            string hours = System.Math.Floor(timeRemaining / 3600000).ToString();
            string minutes = System.Math.Floor(timeRemaining % 3600000 / 60000).ToString();
            string seconds = System.Math.Ceiling(timeRemaining % 3600000 % 60000 / 1000).ToString();
            timeText.text = $"{hours.PadLeft(2, '0')}:{minutes.PadLeft(2, '0')}:{seconds.PadLeft(2, '0')}";
        }
    }

    //executes when image is clicked
    public void onClick()
    {
        if (isRunning)
            return;
        //else
        isRunning = true;
        timeWhenStart = CanvasTime.unixTime;
        toComplete = timeWhenStart + 100 / timeModifier;
    }

    public void onBuy()
    {
        if (level >= 51200)
            return;

        if (Money.money - (basePrice * System.Math.Pow(priceIncreaseModifier, level)) < 0)
            return;

        Money.money -= (basePrice * System.Math.Pow(priceIncreaseModifier, level));
        level++;

        //figuring out time modifier based on level
        if (System.Array.IndexOf(CanvasTime.timesTwoLevels, level) != -1)
            timeModifier *= 2;

        toComplete = timeWhenStart + 100 / timeModifier;


        upgradePrice = basePrice * System.Math.Pow(priceIncreaseModifier, level);
        levelText.text = (level.ToString());

        if (level < 51200 && upgradePrice <= 999999999.99)
            upgradeText.text = $"Buy: {upgradePrice:C}";

        else if (level < 51200 && upgradePrice > 999999999.99)
            upgradeText.text = $"Buy: ${upgradePrice:E}";

        else //level must be = 51200
        {
            upgradeButton.interactable = false;
            upgradeText.text = "Max";
        }

        if (profitPerUnit * level < 999999999.99)
            profitText.text = $"{profitPerUnit * level:C}";
        else
            profitText.text = $"${profitPerUnit * level:E}";
    }
    
}
