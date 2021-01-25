using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalPurchase : MonoBehaviour
{
    public float buyPrice;
    public string idTag;

    public int targetModuleNumber;
    public float multiplier;

    private bool hasBought;

    private Button button;
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        hasBought = SaveTrigger.upgradeData[idTag];

        button = GetComponent<Button>();
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        if (hasBought)
        {
            button.interactable = false;
            text.fontSize = 40;
            text.text = "LEARNT!";
            text.color = new Color(0f, 0.55f, 0f);
            return;
        }

        button.onClick.AddListener(OnClick);

        if (buyPrice <= 999999999)
            text.text = $"Learn\n${buyPrice}";
        else
            text.text = $"Learn\n${buyPrice:E}";

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
        text.text = "LEARNT!";
        text.color = new Color(0f, 0.55f, 0f);

        Money.money -= buyPrice;

        switch (targetModuleNumber)
        {
            case 1:
                ONE.profitModifier *= multiplier;
                break;
            case 2:
                TWO.profitModifier *= multiplier;
                break;
            case 3:
                THREE.profitModifier *= multiplier;
                break;
            case 4:
                FOUR.profitModifier *= multiplier;
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
        SaveTrigger.OnPurchase(idTag);
    }
}
