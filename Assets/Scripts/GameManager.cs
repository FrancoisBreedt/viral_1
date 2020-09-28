using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public List<CellClass> Cells = new List<CellClass>();
    int CellsInSyringe = 100;
    public int Syringes = 0;
    public float TotalCells = 1;
    public float GameTickerInterval = (float)0.5;
    public float DuplicationRate = (float)0.01;
    public float CellStrength = (float)0.1;
    public float HumansInfected = 0;
    public float CureProgress = 0;

    bool IsDestroyingCells = false;
    float CellsInMicroscope = 1;
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

    //Coroutine tmp;
    //private void Start()
    //{
    //     tmp = StartCoroutine(Ticks());
    //}
    //IEnumerator Ticks()
    //{
    //    while(true)
    //    {
    //        Debug.Log("Tick");
    //        Tick();
    //        yield return null;
    //        //yield return new WaitForSeconds(GameTickerInterval);
    //    }
    //}

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
            try
            {
                for (int i = 0; i < Amount; i++)
                {
                    CellClass temp = Cells[Random.Range(0, Cells.Count)];
                    Instantiate(temp.gameObject, (Vector2)temp.transform.position +
                        new Vector2(Random.Range((float)-0.1, (float)0.2), Random.Range((float)-0.1, (float)0.2)), Quaternion.identity);
                }
            }
            catch{}
            if (CellsInMicroscope > CellsInSyringe + 1)
            {
                DestroyCells();
                Syringes++;
                CellsInMicroscope = 1;
            }
        }

    }

    public void DestroyCells()
    {
        IsDestroyingCells = true;
    }

    public void InfectHuman()
    {
        if (Syringes >= 1)
        {
            if (Random.Range(0, 100) < CellStrength)
            {
                HumansInfected++;
            }
            Syringes--;
        }  
    }

}
