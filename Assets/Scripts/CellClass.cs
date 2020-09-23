using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Cells.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
