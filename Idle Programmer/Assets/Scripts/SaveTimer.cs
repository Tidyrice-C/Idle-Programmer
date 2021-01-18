using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    private double currentTime;
    private double lastSavedTime;

    public static SaveData saveData;

    public Money money;
    public ONE one;
    public TWO two;
    public THREE three;
    public FOUR four;

    private void Awake()
    {
        saveData = SaveSystem.LoadData();

        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastSavedTime = CanvasTime.unixTime;
        currentTime = lastSavedTime;

        //money = gameObject.AddComponent<Money>();
        //one = gameObject.AddComponent<ONE>();
    }

    private void Update()
    {
        currentTime = CanvasTime.unixTime;

        if (currentTime - lastSavedTime < 1000)
            return;

        //else
        lastSavedTime = currentTime;
        SaveSystem.SaveAll(money, one, two, three, four);
    }
}
