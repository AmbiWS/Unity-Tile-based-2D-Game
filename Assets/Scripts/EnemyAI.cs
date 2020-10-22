using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EnemyAI : MonoBehaviour {
    public bool isReady;
    public float maxSpeed;
    public float curHealth;
    public bool isLeftSide;
    public float timeLeft;
    public float forLeft;
    public float forRight;
    public bool isAttacking;
    public int damage;
    public float scOnX;
    public float scOnY;
    public float speed;
    public float peakTime;
    public float posX;
    public float posY;
    public static float timePeak = 5f;
    public static float timePeakCounter = 0f;
    public static bool isTimePeak = false;
    public GameObject hearthSP;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Player player;
    private GameObject obj;

    public void setRigidBody(Rigidbody2D rb2d)
    {
        this.rb2d = rb2d;
    }

    public void setAnimator(Animator anim)
    {
        this.anim = anim;
    }

    public void setPlayer(Player player)
    {
        this.player = player;
    }

    public void setObject(GameObject obj)
    {
        this.obj = obj;
    }

    public void FixedUpdate()
    {
        posX = rb2d.position.x;
        posY = rb2d.position.y;

        if (isTimePeak) {
            timePeakCounter += Time.deltaTime;

            if (timePeakCounter >= timePeak) {

                isTimePeak = false;
                timePeakCounter = 0f;
            }
            
            if (!isTimePeak)
            {
                player.game = new GameHistory();
                player.game.History.Add(player.SaveProgress());
            }

            return;
        }

        if (curHealth >= 5)
        {
            float posXDeath = rb2d.position.x;
            float posYDeath = rb2d.position.y + 5;

            Destroy(obj);
            EnemyAI_Rogue.roguesCount--;

            Instantiate(hearthSP, new Vector2(posXDeath, posYDeath), Quaternion.identity);
            isTimePeak = true;
        }

        float dist = player.currentX - rb2d.position.x;
        if (dist < -8 || dist > 8)
        {
            anim.SetBool("isAttack", false);
            anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

            if (!isLeftSide)
                transform.localScale = new Vector3(-scOnX, scOnY, transform.localScale.z);

            if (isLeftSide)
                transform.localScale = new Vector3(scOnX, scOnY, transform.localScale.z);

            if (rb2d.position.x < (forLeft - 5))
            {
                speed = 5f;
                isReady = true;
                timeLeft = 0f;
                rb2d.AddForce(Vector2.right * maxSpeed);
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
                transform.localScale = new Vector3(scOnX, scOnY, transform.localScale.z);
            }

            if (rb2d.position.x > (forRight + 5))
            {
                speed = 5f;
                isReady = true;
                timeLeft = 0f;
                rb2d.AddForce(Vector2.right * -maxSpeed);
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
                transform.localScale = new Vector3(-scOnX, scOnY, transform.localScale.z);
            }

            if (rb2d.position.x >= (forLeft -5) && 
                rb2d.position.x <= (forRight+5))
            {
                if (!isLeftSide)
                {
                    transform.localScale = new Vector3(-scOnX, scOnY, transform.localScale.z);
                    rb2d.AddForce(Vector2.right * -speed);
                    rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                }

                if (isLeftSide)
                {
                    transform.localScale = new Vector3(scOnX, scOnY, transform.localScale.z);
                    rb2d.AddForce(Vector2.right * speed);
                    rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                }

                if (rb2d.position.x >= forRight)
                {
                    isLeftSide = false;
                    
                    if (timeLeft >= peakTime)
                    {
                        isReady = false;
                        timeLeft = peakTime;
                    }
                }

                if (rb2d.position.x <= forLeft)
                {
                    isLeftSide = true;

                    if (timeLeft >= peakTime)
                    {
                        isReady = false;
                        timeLeft = peakTime;
                    }
                }

                if (!isReady)
                {
                    speed = 0f;
                    timeLeft -= Time.deltaTime;
                    if (timeLeft <= 0)
                    {
                        speed = 5f;
                        isReady = true;
                    }
                }
                if (isReady)
                {
                    timeLeft += Time.deltaTime;
                }
            }
        }

        if (dist >= -8 && dist < -4)
        {
            isReady = true;
            speed = 5f;
            transform.localScale = new Vector3(-scOnX, scOnY, transform.localScale.z);
            rb2d.AddForce(Vector2.right * -speed);
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }

        if (dist >= -4 && dist <= 0)
        {
            transform.localScale = new Vector3(-scOnX, scOnY, transform.localScale.z);

            anim.SetBool("isAttack", true);
            player.curHealth += Time.deltaTime;

            if (dist >= -3 && dist <= 0)
            {
                Vector3 v3 = player.transform.localScale;
                if (player.anotherAttackBool && v3.x == 3)
                {
                    curHealth += Time.deltaTime;
                }
            }
        }

        if (dist > 4 && dist <= 8)
        {
            isReady = true;
            speed = 5f;
            transform.localScale = new Vector3(scOnX, scOnY, transform.localScale.z);
            rb2d.AddForce(Vector2.right * speed);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (dist > 0 && dist <= 4)
        {
            transform.localScale = new Vector3(scOnX, scOnY, transform.localScale.z);

            anim.SetBool("isAttack", true);
            player.curHealth += Time.deltaTime;

            if (dist <= 3 && dist > 0)
            {
                Vector3 v3 = player.transform.localScale;
                if (player.anotherAttackBool && v3.x == -3)
                {
                    curHealth += Time.deltaTime;
                }
            }
        }
    }
}
