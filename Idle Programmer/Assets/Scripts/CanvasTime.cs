using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasTime : MonoBehaviour
{ 

    public static int GetUnixTime()
    {
        return (int)(System.DateTime.Now - new DateTime(2020, 1, 1)).TotalSeconds;
    }

}
