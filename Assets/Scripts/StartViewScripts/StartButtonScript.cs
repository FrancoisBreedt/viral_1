using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    float loopTime = 3;
    float loopProgress = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey || Input.touchCount > 0)
        {
            clickSound.Play();
            SceneManager.LoadScene("Main");
        }
        loopProgress += Time.deltaTime;
        if (loopProgress >= loopTime)
        {
            loopProgress = 0;
        }
        Color c = GetComponent<Image>().color;
        c.a = (Mathf.Sin(loopProgress / loopTime * Mathf.PI * 2) + 7) * 0.125f;
        GetComponent<Image>().color = c;
    }

}
