using UnityEngine;
using UnityEngine.UI;

public class ONE : MonoBehaviour
{
    private Slider slider;
    private Button button;
    private Button upgradeButton;

    private TMPro.TextMeshProUGUI profitText;
    private TMPro.TextMeshProUGUI levelText;
    private TMPro.TextMeshProUGUI upgradeText;
    private TMPro.TextMeshProUGUI timeText;

    private double currentTime;
    private double upgradePrice;
    private double toComplete;

    public int startLevel;
    public float basePrice;
    public float levelOneTimeModifier;
    public float priceIncreaseModifier;
    public float profitPerUnit;

    private static bool isRunning = false;
    [HideInInspector] public static double timeWhenStart;
    [HideInInspector] public static int level;
    [HideInInspector] public static double timeModifier;

    private double netProfit;

    //FROM UPGRADES
    [HideInInspector] public static float profitModifier;

    //FROM EXECUTIVES
    [HideInInspector] public static bool automated;

    // Start is called before the first frame update
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        TMPro.TextMeshProUGUI[] texts = GetComponentsInChildren<TMPro.TextMeshProUGUI>();

        slider = GetComponentInChildren<Slider>();

        button = buttons[0];
        button.onClick.AddListener(OnClick);

        upgradeButton = buttons[1];
        upgradeButton.onClick.AddListener(OnBuy);

        profitText = texts[0];
        levelText = texts[1];
        upgradeText = texts[2];
        timeText = texts[3];

        //checks if save file is corrupted 
        try
        {
            level = SaveTimer.saveData.levelOne;
            timeWhenStart = SaveTimer.saveData.timeWhenStartOne;
            timeModifier = SaveTimer.saveData.timeModifierOne;
            profitModifier = SaveTimer.saveData.profitModifierOne;
            automated = SaveTimer.saveData.automatedOne;
        }
        catch
        {
            level = startLevel;
            timeWhenStart = -1;
            timeModifier = levelOneTimeModifier;
            profitModifier = 1;
            automated = false;
            SaveSystem.ResetSave();
        }

        if (level < startLevel || timeModifier <= 0 || profitModifier < 1)
        {
            level = startLevel;
            timeWhenStart = -1;
            timeModifier = levelOneTimeModifier;
            profitModifier = 1;
            automated = false;
            SaveSystem.ResetSave();
        }

        if (timeWhenStart >= CanvasTime.unixTime && timeWhenStart != -1)
            timeWhenStart = -1;
        //end of save file check ^^^;

        if (timeWhenStart != -1)
        {
            isRunning = true;
            toComplete = timeWhenStart + (100 / timeModifier);
        }

        netProfit = profitPerUnit * profitModifier * level;

        //Profit calculator for automated offline time
        if (automated)
        {
            isRunning = true;
            double timeElapsed = CanvasTime.unixTime - timeWhenStart;
            double timePerCompletion = 100 / timeModifier;

            double timesCompleted = System.Math.Floor(timeElapsed / timePerCompletion);
            Money.money += netProfit * timesCompleted;

            timeWhenStart = timeElapsed % timePerCompletion;
        }
        //end of automated check ^^

        if (level == 0)
            button.interactable = false;

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

        if (netProfit < 999999999.99)
            profitText.text = $"{netProfit:C}";
        else
            profitText.text = $"${netProfit:E}";
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
            if (automated)
            {
                timeWhenStart = CanvasTime.unixTime;
                toComplete = timeWhenStart + 100 / timeModifier;
                slider.value = 0;
                Money.money += netProfit;

            } else {

                isRunning = false;
                slider.value = 0;
                Money.money += netProfit;
                timeWhenStart = -1;
            }
        }

        else if (slider.value < 100)
            slider.value = (float)(timeDifference * timeModifier);

        double timeRemaining = toComplete - currentTime;

        if (timeRemaining < 1000 && automated)
        {
            timeText.text = "00:00:00";
            return;
        }

        if (timeRemaining >= 0)
        {
            string hours = System.Math.Floor(timeRemaining / 3600000).ToString();
            string minutes = System.Math.Floor(timeRemaining % 3600000 / 60000).ToString();
            string seconds = System.Math.Ceiling(timeRemaining % 3600000 % 60000 / 1000).ToString();
            timeText.text = $"{hours.PadLeft(2, '0')}:{minutes.PadLeft(2, '0')}:{seconds.PadLeft(2, '0')}";
        }
    }

    private void OnClick()
    {
        if (isRunning)
            return;
        //else
        isRunning = true;
        timeWhenStart = CanvasTime.unixTime;
        toComplete = timeWhenStart + 100 / timeModifier;
    }
    private void OnBuy()
    {
        if (level >= 51200)
            return;

        if (Money.money - (basePrice * System.Math.Pow(priceIncreaseModifier, level)) < 0)
            return;

        Money.money -= (basePrice * System.Math.Pow(priceIncreaseModifier, level));
        level++;

        if (level == 1)
            button.interactable = true;

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

        netProfit = profitPerUnit * profitModifier * level;

        if (netProfit < 999999999.99)
            profitText.text = $"{netProfit:C}";
        else
            profitText.text = $"${netProfit:E}";
    }
    public static void ManagerPurchase()
    {
        automated = true;
        isRunning = true;
    }
}
