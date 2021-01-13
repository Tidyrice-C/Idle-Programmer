using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public double money;
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
        text.text = $"Money: ${money}";
    }
}
