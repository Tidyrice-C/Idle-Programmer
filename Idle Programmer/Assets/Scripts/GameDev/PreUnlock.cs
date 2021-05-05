using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreUnlock : MonoBehaviour
{
    private static GameObject preUnlock;

    // Start is called before the first frame update
    void Awake()
    {
        preUnlock = gameObject;

        if (SaveTimer.unlocked)
            Destroy(preUnlock);
    }
    public static void Unlocked()
    {
        Destroy(preUnlock);
    }

}
