using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningScript : MonoBehaviour
{
    [SerializeField] AudioSource warningBeep;

    float dangerLevel = 0;
    float blinkTime = 0.5f;
    float blinkProgress = 0;
    float beepTime = 10;
    float beepProgress = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
