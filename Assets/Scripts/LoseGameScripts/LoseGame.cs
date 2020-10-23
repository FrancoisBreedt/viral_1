using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    float delayTime = 2;
    float transitionTime = 1;
    float timeProgress = 0;

    void Update()
    {
        timeProgress += Time.deltaTime;
        Color c = GetComponent<Image>().color;
        if (timeProgress >= delayTime && timeProgress < delayTime + transitionTime)
        {
            c.a = Mathf.Cos((timeProgress - delayTime) / transitionTime * (Mathf.PI / 2));
        }
        else if (timeProgress >= delayTime + transitionTime)
        {
            c.a = 0;
            if (Input.anyKey || Input.touchCount > 0)
            {
                clickSound.Play();
                Restart();
            }
        }
        GetComponent<Image>().color = c;
    }

    public void Restart()
    {
        GameManager.instance.Restart();
    }
}
