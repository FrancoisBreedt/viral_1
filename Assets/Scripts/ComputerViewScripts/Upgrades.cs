using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    int DuplicationPriceMult = 100;
    int TickPriceMult = 10;
    int StrengthPriceMult = 1000;
    int DuplicationUpgradeCost;
    int TickUpgradeCost;
    int StrengthUpgradeCost;
    int Syringes;
    private Text DuplicationObject;
    private Text IntervalObject;
    private Text StrengthObject;

    // Start is called before the first frame update
    void Start()
    {
        DuplicationObject = GameObject.Find("btn0").GetComponentInChildren<Text>();
        IntervalObject = GameObject.Find("btn1").GetComponentInChildren<Text>();
        StrengthObject = GameObject.Find("btn2").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DuplicationUpgradeCost = (int)System.Math.Floor(GameManager.instance.DuplicationRate * DuplicationPriceMult);
        TickUpgradeCost = (int)System.Math.Floor(TickPriceMult / GameManager.instance.GameTickerInterval);
        StrengthUpgradeCost = (int)System.Math.Floor(GameManager.instance.CellStrength * StrengthPriceMult);
        Syringes = GameManager.instance.Syringes;
        DuplicationObject.color = Syringes >= DuplicationUpgradeCost ? Color.green : Color.red;
        IntervalObject.color = Syringes >= TickUpgradeCost ? Color.green : Color.red;
        StrengthObject.color = Syringes >= StrengthUpgradeCost ? Color.green : Color.red;
        DuplicationObject.text = "DUPLICATION: " + DuplicationUpgradeCost.ToString();
        IntervalObject.text = "INTERVAL: " + TickUpgradeCost.ToString();
        StrengthObject.text = "STRENGTH: " + StrengthUpgradeCost.ToString();
    }

    public void UpgradeDuplication()
    {
        clickSound.Play();
        if (Syringes >= DuplicationUpgradeCost)
        {
            GameManager.instance.DuplicationRate *= (float)1.1;
            GameManager.instance.Syringes -= DuplicationUpgradeCost;
        }
    }

    public void UpgradeTickInterval()
    {
        clickSound.Play();
        if (Syringes >= TickUpgradeCost)
        {
            GameManager.instance.GameTickerInterval *= (float)0.5;
            GameManager.instance.Syringes -= TickUpgradeCost;
            GameManager.instance.DuplicationRate = (float)0.05;
        }
    }

    public void UpgradeCellStrength()
    {
        clickSound.Play();
        if (Syringes >= StrengthUpgradeCost)
        {
            GameManager.instance.CellStrength *= 2;
            GameManager.instance.Syringes -= StrengthUpgradeCost;
            GameManager.instance.DuplicationRate = (float)0.05;
            GameManager.instance.GameTickerInterval = (float)0.5;
        }
    }
}
