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

    private void Awake()
    {
        saveData = SaveSystem.LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastSavedTime = CanvasTime.GetUnixTime();
        currentTime = lastSavedTime;

        //money = gameObject.AddComponent<Money>();
        //one = gameObject.AddComponent<ONE>();
    }

    private void FixedUpdate()
    {
        currentTime = CanvasTime.GetUnixTime();

        if (currentTime - lastSavedTime < 1000)
            return;

        //else
        lastSavedTime = currentTime;
        SaveSystem.SaveAll(money, one, two, three);
    }
}
