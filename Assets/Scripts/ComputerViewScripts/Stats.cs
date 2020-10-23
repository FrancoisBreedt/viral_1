using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager GM = GameManager.instance;
        GetComponent<Text>().text = "- STATS: " + "\n\n- CELLS: " + RightFormat(GameManager.instance.TotalCells) +
                                    "\n- SYRINGES: " + RightFormat(GameManager.instance.Syringes) +
                                    "\n- HUMANS INFECTED: " + RightFormat(GameManager.instance.HumansInfected) + 
                                    "\n- VIRUS STRENGTH: " + RightFormat(GameManager.instance.CellStrength) + 
                                    "\n- CURE PROGRESS: " + RightFormat(GameManager.instance.CureProgress);
    }
    
    string RightFormat(float x)
    {
        string a, b, c;
        if (x > 1000000000)
        {
            a = Mathf.Floor(x / 1000000000).ToString();
            b = "B";
            c = Mathf.Round((x - Mathf.Floor(x / 1000000000) * 1000000000) / 100000000).ToString();
            return a + b + c;
        } 
        else if (x > 1000000)
        {
            a = Mathf.Floor(x / 1000000).ToString();
            b = "M";
            c = Mathf.Round((x - Mathf.Floor(x / 1000000) * 1000000) / 100000).ToString();
            return a + b + c;
        }
        else if (x > 1000)
        {
            a = Mathf.Floor(x / 1000).ToString();
            b = "M";
            c = Mathf.Round((x - Mathf.Floor(x / 1000) * 1000) / 100).ToString();
            return a + b + c;
        }
        else
        {
            return x.ToString();
        }
    }
}