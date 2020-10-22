using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        anim = gameObject.GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.isJumped = false;
        anim.SetBool("isJumping", false);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.isJumped = false;
        anim.SetBool("isJumping", false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.isJumped = true;
        anim.SetBool("isJumping", true);
    }
}
