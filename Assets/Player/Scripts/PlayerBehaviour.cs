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
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Animations();
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

    } 
}
