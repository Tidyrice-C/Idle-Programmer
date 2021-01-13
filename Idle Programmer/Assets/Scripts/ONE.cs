using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ONE : MonoBehaviour
{

    private Button button;

    public GameObject sliderObject;
    private Slider slider;

    public Money money;

    private double currentTime;
    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public double timeWhenStart;
    [HideInInspector] public int level;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        slider = sliderObject.GetComponent<Slider>();

        if (SaveTimer.saveData == null)
        {
            level = 1;
            return;
        }

        level = SaveTimer.saveData.levelOne;
        isRunning = SaveTimer.saveData.isRunningOne;
        timeWhenStart = SaveTimer.saveData.timeWhenStartOne;
    }

    void Update()
    {
        if (!isRunning)
        {
            slider.value = 0;
            return;
        }

        //else if ISRUNNING = true then DO THIS
        currentTime = CanvasTime.GetUnixTime();

        double timeDifference = currentTime - timeWhenStart;

        if (slider.value >= slider.maxValue)
        {
            isRunning = false;
            money.money += 1 * level;
            return;
        }

        //else (slider increments)
        slider.value = (float) (timeDifference * 0.05);
    }


    //executes when image is clicked
    public void onClick()
    {
        if (isRunning)
            return;
        //else
        isRunning = true;
        timeWhenStart = CanvasTime.GetUnixTime();
    }
    
}
