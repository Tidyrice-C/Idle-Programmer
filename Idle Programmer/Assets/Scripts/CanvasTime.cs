using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasTime : MonoBehaviour
{
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
    }
    public static double GetUnixTime()
    {
        return (double)(System.DateTime.Now - new DateTime(2020, 1, 1)).TotalMilliseconds;
    }

}
