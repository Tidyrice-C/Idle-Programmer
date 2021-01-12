using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ONE : MonoBehaviour
{

    private Button button;

    public GameObject sliderObject;
    private Slider slider;

    private float sliderMaxValue;
    private bool isRunning = false;
    private int currentTime;
    private int timeWhenStart;

    public Money money;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        slider = sliderObject.GetComponent<Slider>();
        sliderMaxValue = slider.maxValue;
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

        int timeDifference = currentTime - timeWhenStart;

        if (slider.value >= sliderMaxValue)
        {
            isRunning = false;
            money.money += 5;
            return;
        }

        //else (slider increments)
        slider.value = timeDifference * 0.05f;
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
