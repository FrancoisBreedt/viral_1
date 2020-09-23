using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{

    private float FlickerTime = (float)0.5;
    private float FlickerTrigger = 0;
    private string Text = "CLICK TO START GAME";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlickerTrigger += Time.deltaTime;
        if (FlickerTrigger >= FlickerTime)
        {
            FlickerTrigger = 0;
            if (Text == "CLICK TO START GAME")
            {
                Text = "CLICK TO START GAME_";
            } 
            else
            {
                Text = "CLICK TO START GAME";
            }
            GameObject.Find("btnStart").GetComponentInChildren<Text>().text = Text;
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Microscope");
    }

}
