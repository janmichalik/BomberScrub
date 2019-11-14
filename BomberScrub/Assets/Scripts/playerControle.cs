using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControle : MonoBehaviour
{

    private void Start()
    {
       
    }

    public float speed = 10f;
    float frontBack;
    float leftRight;
    CharacterController cc;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false; //ustawienie kursora na niewidoczny
    }

    // Update is called once per frame
    void Update()
    {
        //pobranie osi
        frontBack = Input.GetAxis("Vertical") * speed;
        leftRight = Input.GetAxis("Horizontal") * speed;
        //zmiana położenia gracza
        Vector3 playerCon = new Vector3(leftRight, 0, frontBack);
        cc.Move(playerCon * Time.deltaTime);
    }
}
