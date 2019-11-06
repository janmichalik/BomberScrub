using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControle : MonoBehaviour
{
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
