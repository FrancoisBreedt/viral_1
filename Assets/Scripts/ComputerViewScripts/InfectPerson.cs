using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectPerson : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    void Update()
    {
        float a = GetComponentInChildren<Text>().color.a;
        Color c = GameManager.instance.Syringes > 0 ? Color.green : Color.red;
        c.a = a;
        GetComponentInChildren<Text>().color = c;
    }

    public void OnClick()
    {
        clickSound.Play();
        GameManager.instance.InfectHuman();
    }
}
