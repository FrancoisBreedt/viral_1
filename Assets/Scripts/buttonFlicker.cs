using UnityEngine;
using UnityEngine.UI;

public class buttonFlicker : MonoBehaviour
{
    [SerializeField] Text text;

    float progress = 0;
    float time = 2;

    void Update()
    {
        progress += Time.deltaTime;
        if (progress >= time)
        {
            progress = 0;
        }
        Color c = text.color;
        c.a = (Mathf.Sin(progress / time * 2 * Mathf.PI) + 2) * 0.33f;
        text.color = c;
    }
}
