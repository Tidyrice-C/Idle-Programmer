using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHeader : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;

    private string[] headers = {
        "\"Knowledge has a Beginning\nbut no End\"",
        "\"Great Minds are Always\nFeared by Lesser Minds\"",
        "while(!(succeed = try()));",
        "if (sad == true)\nsad = false;",
        "Eat, Sleep, Code",
        "\"Learning to Code is Learning to Create and Innovate\""
    };
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        int randomInteger = Random.Range(0, headers.Length);

        text.text = headers[randomInteger];
    }

}
