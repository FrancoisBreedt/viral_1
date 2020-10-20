using UnityEngine;
using UnityEngine.UI;

public class buttonFlicker1 : MonoBehaviour
{
    [SerializeField] Image image;

    float progress = 0;
    float time = 2;

    void Update()
    {
        progress += Time.deltaTime;
        if (progress >= time)
        {
            progress = 0;
        }
        Color c = image.color;
        c.a = (Mathf.Sin(progress / time * 2 * Mathf.PI) + 2) * 0.33f;
        image.color = c;
    }
}