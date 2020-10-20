using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public static AnimationScript instance;
    public List<CellClass> Cells = new List<CellClass>();

    bool IsDestroyingCells = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves cells offscreen to be destroyed
        if (IsDestroyingCells)
        {
            if (Cells.Count <= 1)
            {
                IsDestroyingCells = false;
            }
            for (int c = Cells.Count - 1; c > 0; c--)
            {
                if (Cells[c] != null)
                {
                    Cells[c].transform.position += new Vector3((float)-0.08, 0, 0);
                    if (Cells[c].transform.position.x < -12)
                    {
                        Destroy(Cells[c].gameObject);
                        Cells.RemoveAt(c);
                    }
                }
            }
            Cells[0].transform.position += new Vector3(0, 0, 0) - Cells[0].transform.position / 50;
        }
        int CellsToMultiply = (int)System.Math.Floor(GameManager.instance.CellsInMicroscope) - Cells.Count;
        Duplicate(CellsToMultiply);

        for (int i = 0; i < Cells.Count; i++)
        {
            Cells[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, GameManager.instance.CellStrength);
        }
    }

    public void Duplicate(int Amount)
    {
        if (Amount > 0 && !IsDestroyingCells)
        {
            for (int i = 0; i < Amount; i++)
            {
                CellClass temp = Cells[Random.Range(0, Cells.Count)];
                Instantiate(temp.gameObject, (Vector2)temp.transform.position +
                    new Vector2(Random.Range((float)-0.1, (float)0.2), Random.Range((float)-0.1, (float)0.2)), Quaternion.identity);
            }
        }
        if (GameManager.instance.DestroyCells)
        {
            DestroyCells();
            GameManager.instance.DestroyCells = false;
        }
    }

    public void DestroyCells()
    {
        IsDestroyingCells = true;
    }
}
