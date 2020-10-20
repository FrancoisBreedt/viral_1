using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CellsInSyringe;
    public int Syringes;
    public float TotalCells;
    public int TotalTicks;
    public float GameTickerInterval;
    public float DuplicationRate;
    public float CellStrength;
    public float HumansInfected;
    public float CureProgress;
    public float CellsInMicroscope;
    public bool DestroyCells;
    public bool PlayerDead;

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

    //Save data
    //PlayerPrefs.SetInt("Cells", 10);
    //PlayerPrefs.GetInt("Cells",0);

    private void Update()
    {
        // Activates game ticker
        GameTickerProgress += Time.deltaTime;
        if (GameTickerProgress >= GameTickerInterval)
        {
            Tick();
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
        TotalTicks++;
        CellsInMicroscope += CellsInMicroscope * DuplicationRate;
        if (CellsInMicroscope > CellsInSyringe + 1)
        {
            DestroyCells = true;
            Syringes++;
            CellsInMicroscope = 1;
        }
    }

    public void InfectHuman()
    {
        if (Syringes >= 1)
        {
            if (Random.Range(0, 10) < CellStrength)
            {
                HumansInfected++;
            }
            Syringes--;
        }  
    }

}
