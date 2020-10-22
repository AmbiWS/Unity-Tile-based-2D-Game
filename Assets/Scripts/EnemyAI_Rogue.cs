using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Rogue : EnemyAI {
    public static int roguesCount = 0;

    private void Start()
    {
        isReady = true;
        maxSpeed = 6f;
        curHealth = 0f;
        isLeftSide = true;
        isAttacking = false;
        damage = 1;
        scOnX = 3f;
        scOnY = 3f;
        speed = 5f;
        setRigidBody(gameObject.GetComponent<Rigidbody2D>());
        setAnimator(gameObject.GetComponent<Animator>());
        setPlayer(GameObject.FindGameObjectWithTag("Hero").GetComponent<Player>());
        setObject(GameObject.FindGameObjectsWithTag("EnemyRogue")[roguesCount]);
        roguesCount++;
    }
}
