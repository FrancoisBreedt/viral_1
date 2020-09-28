using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicroscopeInfo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject.Find("MicroscopeInfo").GetComponent<Text>().text = ">>CELLS: " + GameManager.instance.TotalCells.ToString() + 
                                                                    "\n>>SYRINGES: " + GameManager.instance.Syringes.ToString() + 
                                                                    "\n>>CELL STRENGTH: " + GameManager.instance.CellStrength.ToString();
    }
}
