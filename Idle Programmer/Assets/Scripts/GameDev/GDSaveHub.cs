using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDSaveHub : MonoBehaviour
{
    public static GameDevData GameDevData;
    private void Awake()
    {
        GameDevData = SaveSystem.LoadGameDevData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
