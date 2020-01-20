using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float speed = 20f;
    float frontBack;
    float leftRight;
    CharacterController cc;
    private Animation anim;
    GameObject bomb, gleam, smoke;
    public Vector3 pos, rotat;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["run1"].layer = 1;
        anim["bomb1"].layer = 1;
        anim["bomb1(1)"].layer = 2;
        bomb = Resources.Load("bomb") as GameObject;
        gleam = Resources.Load("gleam") as GameObject;
        smoke = Resources.Load("smoke") as GameObject;
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
            anim.Play("run1");
        }
        if ((Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0))
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            anim.Play("run1");
        }
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
            anim.Play("run1");
        }
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            cc.transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
            anim.Play("run1");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("bomb1(1)");
            anim.Play("bomb1");
            pos = cc.transform.position;
            rotat = cc.transform.eulerAngles;
            GameObject b2 = Instantiate(bomb);
            int addPosx = 0, addPosz = 0;
            if (rotat.y == 0) addPosz = -3;
            else if (rotat.y == 180) addPosz = 3;
            else if (rotat.y == 90) addPosx = -3;
            else addPosx = 3;
            Vector3 bombPos = new Vector3(pos.x + addPosx, 1, pos.z + addPosz);
            b2.transform.position = bombPos;
            StartCoroutine(bombExplosion(bombPos));
            Destroy(b2, 6.5f);
        }
    }
    IEnumerator bombExplosion(Vector3 bombPos)
    {
        yield return new WaitForSeconds(4);
        // 4 promienie
        int gleamRotationY = -90;
        for (int i = 0; i < 4; i++)
        {
            GameObject gleam1 = Instantiate(gleam);
            gleam1.transform.position = bombPos;
            gleam1.transform.eulerAngles = new Vector3(transform.eulerAngles.x, gleamRotationY, transform.eulerAngles.z);
            gleamRotationY += 90;
        }

        //dym z bomby
        yield return new WaitForSeconds(2);
        GameObject smoke1 = Instantiate(smoke);
        smoke1.transform.position = bombPos;


        yield return new WaitForSeconds(1);
        var G = GameObject.FindGameObjectsWithTag("gleam");
        foreach (GameObject item in G)
        {
            Destroy(item);
        }
        var S = GameObject.FindGameObjectsWithTag("smoke");
        foreach (GameObject item in S)
        {
            Destroy(item);
        }

    }
}
