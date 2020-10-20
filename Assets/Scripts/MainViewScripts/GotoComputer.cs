using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoComputer : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    public void OnClick()
    {
        clickSound.Play();
        SceneManager.LoadScene("Computer");
    }
}
