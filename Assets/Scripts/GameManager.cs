using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<CellClass> Cells = new List<CellClass>();

    bool IsDestroyingCells = false;
    int CellsInSyringe = 100;
    int Syringes = 0;
    float TotalCells = 1;
    float CellsInMicroscope = 1;
    float DuplicationRate = (float)0.01;
    float GameTickerInterval = (float)0.5;
    float GameTickerProgress = 0;

    public static GameManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            Initialize();
        }
    }

    private void Update()
    {
        // Activates game ticker
        GameTickerProgress += Time.deltaTime;
        if (GameTickerProgress >= GameTickerInterval)
        {
            Tick();
        }
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
            Cells[0].transform.position += new Vector3(0, 0, 0) - Cells[0].transform.position/50;
        }
        // Updates total number of cells
        TotalCells = Syringes * CellsInSyringe + CellsInMicroscope;
    }

    private void Initialize()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Tick()
    {
        GameTickerProgress = 0;
        CellsInMicroscope += CellsInMicroscope * DuplicationRate;
        int CellsToMultiply = (int)System.Math.Floor(CellsInMicroscope) - Cells.Count;
        Duplicate(CellsToMultiply);
    }

    public void Click()
    {
        Tick();
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
            if (Cells.Count > CellsInSyringe)
            {
                DestroyCells();
                Syringes += 1;
                CellsInMicroscope = 1;
            }
        }

    }

    public void DestroyCells()
    {
        IsDestroyingCells = true;
    }

}
