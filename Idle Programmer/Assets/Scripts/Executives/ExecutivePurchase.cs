using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecutivePurchase : MonoBehaviour
{
    public float buyPrice;
    public int targetModuleNumber;

    private bool hasBought;

    private Button button;
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        switch (targetModuleNumber)
        {
            case 1:
                hasBought = ONE.automated;
                break;
            case 2:
                hasBought = TWO.automated;
                break;
            case 3:
                hasBought = THREE.automated;
                break;
            case 4:
                hasBought = FOUR.automated;
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }

        button = GetComponent<Button>();
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        if (hasBought)
        {
            button.interactable = false;
            text.fontSize = 40;
            text.text = "HIRED!";
            text.color = new Color(1f, 0.2f, 0.2f);
            return;
        }

        button.onClick.AddListener(OnClick);

        if (buyPrice <= 999999999)
            text.text = $"Hire\n${buyPrice}";
        else
            text.text = $"Hire\n${buyPrice:E}";

        if (Money.money < buyPrice)
            button.interactable = false;
    }
    void Update()
    {
        if (hasBought)
            return;

        if (Money.money >= buyPrice)
            button.interactable = true;
        else
            button.interactable = false;
    }

    public void OnClick()
    {
        hasBought = true;
        button.interactable = false;
        text.fontSize = 40;
        text.text = "HIRED!";
        text.color = new Color(1f, 0.2f, 0.2f);

        Money.money -= buyPrice;

        switch (targetModuleNumber)
        {
            case 1:
                ONE.ManagerPurchase();
                break;
            case 2:
                TWO.ManagerPurchase();
                break;
            case 3:
                THREE.ManagerPurchase();
                break;
            case 4:
                FOUR.ManagerPurchase();
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }

        SaveSystem.SaveAll();
    }
}
