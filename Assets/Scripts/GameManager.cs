using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CellsInSyringe;
    public int Syringes;
    public float TotalCells;
    public float GameTickerInterval;
    public float DuplicationRate;
    public float CellStrength;
    public float HumansInfected;
    public float CureProgress;
    public float CellsInMicroscope;
    public bool DestroyCells;
    public bool PlayerDead = false;
    public string DeathType;

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
        if (PlayerDead)
        {
            SceneManager.LoadScene(4);
            PlayerDead = false;
        }
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
        Syringes = PlayerPrefs.GetInt("Syringes", Syringes);
        CellsInMicroscope = PlayerPrefs.GetFloat("CellsInMicroscope", CellsInMicroscope);
        GameTickerInterval = PlayerPrefs.GetFloat("GameTickerInterval", GameTickerInterval);
        DuplicationRate = PlayerPrefs.GetFloat("DuplicationRate", DuplicationRate);
        CellStrength = PlayerPrefs.GetFloat("CellStrength", CellStrength);
        HumansInfected = PlayerPrefs.GetFloat("HumansInfected", HumansInfected);
        CureProgress = PlayerPrefs.GetFloat("CureProgress", CureProgress);
    }

    public void Tick()
    {
        GameTickerProgress = 0;
        CellsInMicroscope += CellsInMicroscope * DuplicationRate;
        HumansInfected += HumansInfected * Random.Range(-0.1f, CellStrength/5);
        HumansInfected = HumansInfected < 0.5f ? 0 : HumansInfected;
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
            if (Random.Range(0, 1) < CellStrength)
            {
                HumansInfected++;
            }
            Syringes--;
        }  
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Syringes", 0);
        PlayerPrefs.SetFloat("CellsInMicroscope", 1);
        PlayerPrefs.SetFloat("GameTickerInterval", 0.5f);
        PlayerPrefs.SetFloat("DuplicationRate", 0.05f);
        PlayerPrefs.SetFloat("CellStrength", 0.1f);
        PlayerPrefs.SetFloat("HumansInfected", 0);
        PlayerPrefs.SetFloat("CureProgress", 0);
        SceneManager.LoadScene(0);
        Destroy(this);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Syringes", Syringes);
        PlayerPrefs.SetFloat("CellsInMicroscope", CellsInMicroscope);
        PlayerPrefs.SetFloat("GameTickerInterval", GameTickerInterval);
        PlayerPrefs.SetFloat("DuplicationRate", DuplicationRate);
        PlayerPrefs.SetFloat("CellStrength", CellStrength);
        PlayerPrefs.SetFloat("HumansInfected", HumansInfected);
        PlayerPrefs.SetFloat("CureProgress", CureProgress);
    }
}
