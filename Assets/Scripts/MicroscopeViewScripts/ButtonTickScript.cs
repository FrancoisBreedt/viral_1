using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTickScript : MonoBehaviour
{
    [SerializeField] GameObject inject;

    float clickTime = 0.1f;
    float clickProgress = 0;
    bool clicking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicking)
        {
            Color c = inject.GetComponent<Image>().color;
            clickProgress += Time.deltaTime;
            if (clickProgress > clickTime)
            {
                clickProgress = 0;
                clicking = false;
                c.a = 0;
            }
            else
            {
                c.a = Mathf.Sin(clickProgress / clickTime * Mathf.PI) * 0.2f;
            }
            inject.GetComponent<Image>().color = c;
        }
    }

    public void OnClick()
    {
        GameManager.instance.Tick();
        clicking = true;
    }
}
