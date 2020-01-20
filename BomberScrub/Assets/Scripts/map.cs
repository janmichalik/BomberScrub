using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class map : MonoBehaviour
{
    //zmienne kamery
    Camera perspCamera, topCamera, ortoCamera;
    GameObject cam;
    public Camera m_CameraTwo;


    // Start is called before the first frame update
    void Start()
    {
        GameObject block = Resources.Load ("Block") as GameObject;
        GameObject crate = Resources.Load("Crate") as GameObject;
        GameObject player1 = Resources.Load("player1") as GameObject;
        GameObject player2 = Resources.Load("player2") as GameObject;
        for (int i=1; i<17; ++i)
        {
            for(int j=1; j<9; ++j)
            {
                // generowanie stalych elementow
                GameObject go = Instantiate(block);
                go.transform.position = new Vector3(6 * i - 1, (float)1.5, 8 * j);

                if(j > 1)
                {
                    // generowanie zniszczalnych elementw
                    // TODO: zrobic z tego funkcje
                    GameObject box = Instantiate(crate);
                    box.transform.position = new Vector3(6 * i - 1, (float)1.5, (float)3.9 + 8 * (j - 1));
                    box.transform.localScale -= new Vector3((float)0.2, (float)0.2, (float)0.2);
                    Renderer rend = box.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                }
            }

            for(int j=1; j<18; ++j)
            {
                if (i < 16)
                {
                    GameObject box = Instantiate(crate);
                    box.transform.position = new Vector3(6 * i + 2, (float)1.5, (float) 3.9 * j);
                    box.transform.localScale -= new Vector3((float) 0.2, (float)0.2, (float)0.2);
                    Renderer rend = box.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                }
            }
        }

        //generowanie graczy
        GameObject p1 = Instantiate(player1);
        p1.transform.position = new Vector3(2, 0, 68);

        GameObject p2 = Instantiate(player2);
        p2.transform.position = new Vector3(98, 0, 2);


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
