using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CellsInSyringe = 100;
    public int Syringes = 0;
    public float TotalCells = 1;
    public float GameTickerInterval = (float)0.5;
    public float DuplicationRate = (float)0.01;
    public float CellStrength = (float)0.1;
    public float HumansInfected = 0;
    public float CureProgress = 0;
    public float CellsInMicroscope = 1;
    public bool DestroyCells = false;

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
        CellsInMicroscope += CellsInMicroscope * DuplicationRate;
        if (CellsInMicroscope > CellsInSyringe + 1)
        {
            DestroyCells = true;
            Syringes++;
            CellsInMicroscope = 1;
        }
    }

    public void Click()
    {
        Tick();
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
