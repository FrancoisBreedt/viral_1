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
        GetComponent<Text>().text = "- STATS: " + "\n\n- CELLS: " + System.Math.Floor(GameManager.instance.TotalCells).ToString() +
                                    "\n- SYRINGES: " + GameManager.instance.Syringes.ToString() +
                                    "\n- HUMANS INFECTED: " + System.Math.Floor(GameManager.instance.HumansInfected).ToString() + 
                                    "\n- VIRUS STRENGTH: " + GameManager.instance.CellStrength.ToString() + 
                                    "\n- CURE PROGRESS: " + GameManager.instance.CureProgress.ToString();
    }
}