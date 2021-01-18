using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasTime : MonoBehaviour
{

    public static double unixTime;
    public static int[] timesTwoLevels = {25, 50, 100, 200, 400, 800, 1600, 3200, 6400, 12800, 25600, 51200};

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            //if game is fullscreen
            if (Screen.fullScreen)
                Screen.fullScreenMode = FullScreenMode.Windowed;
            else
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }

        UpdateUnixTime();
    }

    public static void UpdateUnixTime()
    {
        unixTime = (DateTime.Now - new DateTime(2021, 1, 1)).TotalMilliseconds;
    }
}
