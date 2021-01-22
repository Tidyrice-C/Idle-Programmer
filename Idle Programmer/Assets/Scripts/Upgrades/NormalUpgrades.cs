using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalUpgrades : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        button.interactable = false;
    }
    public void TabSwitch(int ID)
    {
        if (ID == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            button.interactable = false;
        }

        if (ID == 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            button.interactable = true;
        }
    }
}
