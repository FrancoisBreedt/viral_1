using System.Collections;
using UnityEngine;

public class CellClass : MonoBehaviour
{
    //IEnumerator Move()
    //{
    //    while (true)
    //    {
    //        transform.position += new Vector3(Random.Range((float)-0.05, (float)0.05), Random.Range((float)-0.05, (float)0.05), 0);
    //        yield return new WaitForSeconds((float)0.25);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Move());
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
