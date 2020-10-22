using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_WizardHuman : EnemyAI {

    private void Start()
    {
        isReady = true;
        maxSpeed = 6f;
        curHealth = 0f;
        isLeftSide = true;
        timeLeft = 2f;
        forLeft = 72f;
        forRight = 87f;
        isAttacking = false;
        damage = 1;
        scOnX = 0.4f;
        scOnY = 0.5f;
        speed = 5f;
        peakTime = 2f;
        setRigidBody(gameObject.GetComponent<Rigidbody2D>());
        setAnimator(gameObject.GetComponent<Animator>());
        setPlayer(GameObject.FindGameObjectWithTag("Hero").GetComponent<Player>());
        setObject(GameObject.FindGameObjectWithTag("EnemyHumanWizard"));
    }
}
