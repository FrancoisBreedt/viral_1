using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMicroscope : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Microscope");
    }
}
