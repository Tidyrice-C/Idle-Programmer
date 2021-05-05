using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    private Button button;
    private TMPro.TextMeshProUGUI text;

    private bool unlocked;
    public double unlockPrice;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        button.onClick.AddListener(OnClick);

        unlocked = SaveTimer.unlocked;

        if (unlocked)
            button.interactable = false;

        text.text = $"Unlock!\n{unlockPrice:E}";
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
            return;

        if (Money.money < unlockPrice)
            button.interactable = false;
        else
            button.interactable = true;
    }
    private void OnClick()
    {
        Money.money -= unlockPrice;
        button.interactable = false;
        SaveTimer.unlocked = true;
        unlocked = true;
        SaveSystem.SaveAll();
        SaveSystem.SaveGameDev();
        PreUnlock.Unlocked();
    }
}
