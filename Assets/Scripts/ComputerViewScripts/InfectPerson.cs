using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectPerson : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    void Update()
    {
        GetComponentInChildren<Text>().color = GameManager.instance.Syringes > 0 ? Color.green : Color.red;
    }

    public void OnClick()
    {
        clickSound.Play();
        GameManager.instance.InfectHuman();
    }
}
