using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalPurchase : MonoBehaviour
{
    public float buyPrice;
    public string serializeID;

    public static string idTag;

    private static bool hasBought;

    private Button button;
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        idTag = serializeID;

        button = GetComponent<Button>();
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        button.onClick.AddListener(OnClick);

        if (buyPrice <= 999999999)
            text.text = $"Money\n${buyPrice}";
        else
            text.text = $"Money\n${buyPrice:E}";

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

    void OnClick()
    {
        button.interactable = false;
        hasBought = true;

        Money.money -= buyPrice;

        SaveTrigger.OnPurchase(idTag);
    }
}
