using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControle : MonoBehaviour
{

    private void Start()
    {
       /* int direction = 1;
        GameObject prefab = Resources.Load ("Block") as GameObject;
        for(int i=1; i<5; ++i)
        {
            for(int j=1; j<5; ++j)
            {
                if (i % 2 == 0)
                    direction = -1;
                else
                    direction = 1;
                GameObject go = Instantiate(prefab);
                go.transform.position = new Vector3(4 * i * direction, 15 / 10, 8 * j * direction);
            }
        }*/
    }

    public float speed = 10f;
    float frontBack;
    float leftRight;
    CharacterController cc;
    // Start is called before the first frame update
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        frontBack = Input.GetAxis("Vertical") * speed;
        leftRight = Input.GetAxis("Horizontal") * speed;
        Vector3 playerCon = new Vector3(leftRight, 0, frontBack);
        cc.Move(playerCon * Time.deltaTime);
    }
}
