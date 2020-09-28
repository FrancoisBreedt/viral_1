using UnityEngine;

public class CellClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnimationScript.instance.Cells.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        AnimationScript.instance.Cells.Remove(this);
    }
}
