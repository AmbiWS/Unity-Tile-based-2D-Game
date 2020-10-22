using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHearthTouch : MonoBehaviour {

    Player player;
    GameObject obj;
    Rigidbody2D rb2d;
    public static bool isNear = false;
    public static int hearthsCount = -1;

    private void Awake()
    {
        hearthsCount++;
        obj = GameObject.FindGameObjectsWithTag("FallenHearth")[hearthsCount];
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Hero").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        float dsds = rb2d.position.x;
        float isos = player.currentX;
        
        float dist = isos - dsds;
        float distY = player.currentY - rb2d.position.y;

        isNear = false;
        if (dist >= -2 && dist <= 2 && distY <= 2 && distY >= -2)
        {
            isNear = true;
            Destroy(obj);
            hearthsCount--;
        }
    }
}
