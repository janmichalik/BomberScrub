using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControle : MonoBehaviour
{

    public float speed = 20f;
    float frontBack;
    float leftRight;
    CharacterController cc;
    private Animation anim;
    GameObject bomb;
    public Vector3 pos, rotat;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["running"].layer = 1;
        anim["droppingBomb"].layer = 1;
        anim["droppingBomb(1)"].layer = 2;
        bomb = Resources.Load("bomb") as GameObject;
    }
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
        if ((Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0))
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            anim.Play("running");
        }
        if ((Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0))
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            anim.Play("running");
        }
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
            anim.Play("running");
        }
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
            anim.Play("running");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("droppingBomb(1)");
            anim.Play("droppingBomb");
            pos = cc.transform.position;
            rotat = cc.transform.eulerAngles;
            GameObject b2 = Instantiate(bomb);
            int addPosx = 0, addPosz = 0;
            if (rotat.y == 0) addPosz = -3;
            else if (rotat.y == 180) addPosz = 3;
            else if (rotat.y == 90) addPosx = -3;
            else addPosx = 3;
            b2.transform.position = new Vector3(pos.x + addPosx, 1, pos.z + addPosz);
            Destroy(b2, 5f);
        }
    }
}
