using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject block = Resources.Load ("Block") as GameObject;
        for(int i=1; i<17; ++i)
        {
            for(int j=1; j<9; ++j)
            {
                GameObject go = Instantiate(block);
                go.transform.position = new Vector3(6 * i, 15 / 10, 8 * j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
