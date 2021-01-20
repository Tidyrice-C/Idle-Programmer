using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static double money;
    private TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();

        if (SaveTimer.saveData == null)
        {
            money = 0.00;
            return;
        }

        money = SaveTimer.saveData.money;
    }

    // Update is called once per frame
    void Update()
    {
        money = System.Math.Round(money, 2);

        if (money <= 999999999999.99)
            text.text = $"Money: {money:C}";

        else
            text.text = $"Money: ${money:E}";
    }
}
