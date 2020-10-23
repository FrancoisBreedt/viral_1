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
        float a = DuplicationObject.color.a;
        Color c = Syringes >= DuplicationUpgradeCost ? Color.green : Color.red;
        c.a = a;
        DuplicationObject.color = c;
        a = IntervalObject.color.a;
        c = Syringes >= TickUpgradeCost ? Color.green : Color.red;
        c.a = a;
        IntervalObject.color = c;
        a = StrengthObject.color.a;
        c = Syringes >= StrengthUpgradeCost && StrengthUpgradeCost < 1000 ? Color.green : Color.red;
        c.a = a;
        StrengthObject.color = c;
        DuplicationObject.text = "DUPLICATION: " + DuplicationUpgradeCost.ToString();
        IntervalObject.text = "INTERVAL: " + TickUpgradeCost.ToString();
        if (StrengthUpgradeCost < 1000)
        {
            StrengthObject.text = "STRENGTH: " + StrengthUpgradeCost.ToString();
        } 
        else
        {
            StrengthObject.text = "STRENGTH: MAX";
        }
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
        if (Syringes >= StrengthUpgradeCost && GameManager.instance.CellStrength < 1)
        {
            GameManager.instance.CellStrength += 0.1f;
            GameManager.instance.Syringes -= StrengthUpgradeCost;
            GameManager.instance.DuplicationRate = (float)0.05;
            GameManager.instance.GameTickerInterval = (float)0.5;
        }
    }
}
