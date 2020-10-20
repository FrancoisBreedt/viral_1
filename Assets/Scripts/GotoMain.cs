using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMain : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    public void OnClick()
    {
        clickSound.Play();
        SceneManager.LoadScene("Main");
    }
}
