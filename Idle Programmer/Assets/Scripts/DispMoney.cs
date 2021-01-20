using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispMoney : MonoBehaviour
{
    private TMPro.TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Money.money <= 999999999999.99)
            moneyText.text = $"Money: {Money.money:C}";

        else
            moneyText.text = $"Money: ${Money.money:E}";
    }
}
