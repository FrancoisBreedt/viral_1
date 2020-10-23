using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightFlicker : MonoBehaviour
{
    float delayTime;
    float flickerTime;
    int pulses;
    float progress = 0;
    bool lightOn = true;
    // Start is called before the first frame update
    void Start()
    {
        delayTime = Random.Range(1, 5);
        flickerTime = Random.Range(0.01f, 0.1f);
        pulses = Random.Range(1, 8) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress >= delayTime)
        {
            if (pulses == 0)
            {
                progress = 0;
                delayTime = Random.Range(1, 5);
                flickerTime = Random.Range(0.01f, 0.1f);
                pulses = Random.Range(1, 8) * 2;
            }
            else if (progress > delayTime + flickerTime)
            {
                progress = delayTime;
                lightOn = !lightOn;
                pulses--;
                flickerTime = Random.Range(0.01f, 0.1f);
            }
        }
        Color c = GetComponent<Image>().color;
        c.a = lightOn ? 0 : 0.5f;
        GetComponent<Image>().color = c;
    }
}
