using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMicroscope : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    public void OnClick()
    {
        clickSound.Play();
        SceneManager.LoadScene("Microscope");
    }
}
