using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ONE : MonoBehaviour
{

    private Button button;

    public GameObject sliderObject;
    private Slider slider;

    private bool isRunning = false;
    private double currentTime;
    private double timeWhenStart;
    public int level;

    public Money money;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        slider = sliderObject.GetComponent<Slider>();
        level = 1;
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
