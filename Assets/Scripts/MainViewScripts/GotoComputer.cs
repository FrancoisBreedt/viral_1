using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoComputer : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Computer");
    }
}
