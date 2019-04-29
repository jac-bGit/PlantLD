using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    //stats
    public int maxHp, hp;
    public int maxSpeed, speed;
    public int maxStrenght, strenght;
    public bool poisoned, death;
    //items
    [Header("Items")]
    public int maxItems;
    public int water, manure;
    //fruits
    public enum Fruit { Hp, Speed, Strenght, Antidote}
    public int[] fruits;

    //game state
    public enum GameplayState { Playing, Pause, Lose, Win}
    public static GameplayState gameplayState; 

    //components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        //get components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //set stats
        speed = maxSpeed;
        hp = maxHp;
        strenght = maxStrenght;
        poisoned = false;

        //set fruits
        fruits = new int[System.Enum.GetValues(typeof(Fruit)).Length];

        //start coroutines
        StartCoroutine("Poisoned");
        StartCoroutine(RepairHp());
        StartCoroutine(RepairSpeed());
        StartCoroutine(RepairStrenght());

        gameplayState = GameplayState.Playing;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Animations();
        SettingUpStats();
        GameState();
    }

    //moving 
    void Movement()
    {
        //axis
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //move
        Vector2 move = new Vector2(hor * speed * Time.fixedDeltaTime, ver * speed * Time.fixedDeltaTime);
        rb.velocity = move;
    }

    void SettingUpStats()
    {
        if (hp > maxHp * 2)
            hp = maxHp * 2;
        if (speed > maxSpeed * 2)
            speed = maxSpeed * 2;
        if (speed < maxSpeed / 2f)
        {
            float res = (maxSpeed / 2f);
            Debug.Log(res);
            speed = (int)res;
        }
        if (strenght > maxStrenght * 2)
            strenght = maxStrenght * 2;
        if (strenght < 1)
            strenght = 1;
    }

    void Die()
    {
        if (hp <= 0)
            death = true;
        else
            death = false;
    }


    IEnumerator Poisoned()
    {
        while (true)
        {
            if (poisoned)
                hp -= 2;

            yield return new WaitForSeconds(1);
        }
    }

    //hp
    IEnumerator RepairHp()
    {
        while (true)
        {
            if (hp > maxHp)
                hp--;
            yield return new WaitForSeconds(1);
        }
    }

    //speed
    IEnumerator RepairSpeed()
    {
        while (true)
        {
            if (speed > maxSpeed)
                speed -= 2;
            yield return new WaitForSeconds(1);
        }
    }

    //strenght
    IEnumerator RepairStrenght()
    {
        while (true)
        {
            if (strenght > maxStrenght)
                strenght--;
            yield return new WaitForSeconds(5);
        }
    }



    //get carried items
    public int itemsCount() { return water + manure; }



    void Animations()
    {
        if (rb.velocity.x > 0)
        {
            anim.SetInteger("velX", 1);
            spriteRenderer.flipX = false;
        }
        if (rb.velocity.x < 0)
        {
            anim.SetInteger("velX", -1);
            spriteRenderer.flipX = true;
        }
        if (rb.velocity.x == 0)
            anim.SetInteger("velX", 0);

        if (rb.velocity.y > 0)
            anim.SetInteger("velY", 1);
        if (rb.velocity.y < 0)
            anim.SetInteger("velY", -1);
        if (rb.velocity.y == 0)
            anim.SetInteger("velY", 0);


        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            anim.SetBool("moving", true);
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
            anim.SetBool("moving", false);
    } 


    //control game states
    void GameState()
    {
        //change states
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameplayState == GameplayState.Pause)
                gameplayState = GameplayState.Playing;
            else if (gameplayState == GameplayState.Playing)
                gameplayState = GameplayState.Pause;
        }

        //die
        if (hp <= 0)
            gameplayState = GameplayState.Lose;

        //switch state
        switch (gameplayState)
        {
            case GameplayState.Playing:
                Time.timeScale = 1;
                break;
            case GameplayState.Pause:
                Time.timeScale = 0;
                break;
            case GameplayState.Lose:
                Time.timeScale = 0;
                break;
        }
    }
}
