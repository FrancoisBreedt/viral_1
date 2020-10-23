using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningScript : MonoBehaviour
{
    [SerializeField] AudioSource warningBeep;

    private float dangerLevel = 0;
    private float blinkTime = 0.5f;
    private float blinkProgress = 0;
    private float beepTime = 10;
    private float beepProgress = 10;

    void Update()
    {
        dangerLevel = (GameManager.instance.DuplicationRate / GameManager.instance.GameTickerInterval) - 1;
        if (dangerLevel > 0)
        {
            blinkProgress += Time.deltaTime;
            if (blinkProgress >= blinkTime)
            {
                blinkProgress = 0;
            }
            Color c = GetComponent<Image>().color;
            c.a = (Mathf.Sin(blinkProgress / blinkTime * 2 * Mathf.PI) + 1) * 0.5f;
            GetComponent<Image>().color = c;

            beepProgress += Time.deltaTime;
            if (beepProgress >= beepTime)
            {
                beepProgress = 0;
                warningBeep.Play();
            }
        }
        if (dangerLevel > Random.Range(1, 2))
        {
            GameManager.instance.PlayerDead = true;
            GameManager.instance.DeathType = "Virus";
        }
    }
}
