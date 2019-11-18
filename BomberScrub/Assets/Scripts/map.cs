using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    //zmienne kamery
    Camera perspCamera, topCamera, ortoCamera;
    GameObject cam;
    int whichCamera = 1;
    public Camera m_CameraTwo;

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

        // zaminicjalizowanie zmiennych kamery
        foreach (Camera c in Camera.allCameras)
        {
            if (c.gameObject.name == "OrtoCamera") ortoCamera = c;
            if (c.gameObject.name == "PerspCamera") perspCamera = c;
            if (c.gameObject.name == "TopCamera") topCamera = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f1"))
        {
            ortoCamera.enabled = true;
            topCamera.enabled = false;
            perspCamera.enabled = false;
        }
        if (Input.GetKeyDown("f2"))
        {
            ortoCamera.enabled = false;
            topCamera.enabled = false;
            perspCamera.enabled = true;
        }
        if (Input.GetKeyDown("f3"))
        {
            ortoCamera.enabled = false;
            topCamera.enabled = true;
            perspCamera.enabled = false;
        }
    }
}
