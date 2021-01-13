using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasTime : MonoBehaviour
{ 

    public static double GetUnixTime()
    {
        return (double)(System.DateTime.Now - new DateTime(2020, 1, 1)).TotalMilliseconds;
    }

}
