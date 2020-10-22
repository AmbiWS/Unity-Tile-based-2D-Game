using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public GameHistory game;
    public float speed = 5f;
    public float maxSpeed = 7.5f;
    public float curHealth = 0;
    public bool anotherAttackBool = false;
    public int damage = 2;
    public static bool onceRt = false;

    public bool isAttacking = false;

    public bool isJumped = false;
    public float jumpPower = 500f;
    public float currentX;
    public float currentY;

    private Rigidbody2D rb2d;
    private Animator anim;

    void Restart()
    {
        if (!onceRt)
        {
            EnemyAI_Rogue.roguesCount = 0;
            SceneManager.LoadScene("FirstChapterLevel");
            onceRt = true;
        }
    }

	// Use this for initialization
	void Start () {
        Restart();
        game = new GameHistory();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentX = rb2d.position.x;
        currentY = rb2d.position.y;
    }

    // Update is called once per frames
    void Update() {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
            transform.localScale = new Vector3(-3, 3, 3);

        if (Input.GetAxis("Horizontal") > 0.1f)
            transform.localScale = new Vector3(3, 3, 3);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.N) && !EnemyAI.isTimePeak)
        {
            game = new GameHistory();
            game.History.Add(SaveProgress());
        }

        if (Input.GetKeyDown(KeyCode.M) && !EnemyAI.isTimePeak)
        {
            int size = game.History.Count - 1;
            LoadProgress(game.History[size]);
        }

        if (DropHearthTouch.isNear)
        {
            curHealth = 0;
            DropHearthTouch.isNear = false;
        }

        currentX = rb2d.position.x;
        currentY = rb2d.position.y;
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        if (curHealth >= 10) {
            EnemyAI_Rogue.roguesCount = 0;
            SceneManager.LoadScene("FirstChapterLevel");
        }

        if (!isJumped)
        {
            rb2d.velocity = easeVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (Input.GetAxis("Horizontal") > 0.01)
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        if (Input.GetAxis("Horizontal") < -0.01)
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);

        if (Input.GetMouseButton(0) && Input.GetAxis("Horizontal") > 0.1)
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);

        if (Input.GetMouseButton(0) && Input.GetAxis("Horizontal") < -0.1)
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);

        if (Input.GetButton("Jump") && !isJumped)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        if (!isJumped) {
            anotherAttackBool = Input.GetMouseButton(0);
            anim.SetBool("isAttack", Input.GetMouseButton(0));  
        }

        if (isJumped)
        {
            anotherAttackBool = Input.GetMouseButton(0);
            anim.SetBool("isAttack", false);
        }
    }

    public Memento SaveProgress()
    {
        Debug.Log(curHealth);
        Debug.Log(currentX);
        Debug.Log(currentY);
        Debug.Log("---");

        float[] enemyHp = new float[EnemyAI_Rogue.roguesCount];
        float[] enemyCurX = new float[EnemyAI_Rogue.roguesCount];
        float[] enemyCurY = new float[EnemyAI_Rogue.roguesCount];
        EnemyAI enemy;

        for (int i = 0; i <= EnemyAI_Rogue.roguesCount - 1; i++)
        {
            enemy = GameObject.FindGameObjectsWithTag("EnemyRogue")[i].GetComponent<EnemyAI>();
            enemyHp[i] = enemy.curHealth;
            enemyCurX[i] = enemy.posX;
            enemyCurY[i] = enemy.posY;

            Debug.Log(enemy.curHealth);
            Debug.Log(enemy.posX);
            Debug.Log(enemy.posY);
            Debug.Log("---");
        }

        return new Memento(curHealth, currentX, currentY, EnemyAI_Rogue.roguesCount, enemyHp, enemyCurX, enemyCurY);
    }

    public void LoadProgress(Memento memento)
    {
        this.curHealth = memento.curHealth;
        rb2d.position = new Vector2(memento.currentX, memento.currentY);
        EnemyAI enemy;
        Rigidbody2D enemyrb2d;

        for (int i = 0; i <= EnemyAI_Rogue.roguesCount - 1; i++)
        {
            enemy = GameObject.FindGameObjectsWithTag("EnemyRogue")[i].GetComponent<EnemyAI>();
            enemyrb2d = GameObject.FindGameObjectsWithTag("EnemyRogue")[i].GetComponent<Rigidbody2D>();
            enemy.curHealth = memento.enemyHp[i];
            enemyrb2d.position = new Vector2(memento.enemyPosX[i], memento.enemyPosY[i]);
        }
    }
}
