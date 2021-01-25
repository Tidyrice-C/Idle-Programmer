using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{

    public static SaveData saveData;

    private void Awake()
    {
        saveData = SaveSystem.LoadData();

        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Time.frameCount % 30 != 0)
            return;

        SaveSystem.SaveAll();
    }
}
