using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseText : MonoBehaviour
{
    

    void Update()
    {
        if (GameManager.instance.DeathType == "Virus")
        {
            GetComponent<Text>().text = "- THE VIRUS DUPLICATED TOO FAST AND YOU GOT INFECTED. TOO BAD YOU PAID NO ATTENTION TO THE WARNING...";
        }
    }
}
