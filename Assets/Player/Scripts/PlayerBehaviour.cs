using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    //stats
    public int maxHp, hp;
    public int maxSpeed, speed;
    public int maxStrenght, strenght;
    public bool poisoned;
    //items
    [Header("Items")]
    public int maxItems;
    public int water, manure;
    //fruits
    public enum Fruit { Hp, Speed, Strenght, Antidote}
    public int[] fruits;

    //components
    private Rigidbody2D rb; 

    // Use this for initialization
    void Start () {
        //get components
        rb = GetComponent<Rigidbody2D>();

        //set stats
        speed = maxSpeed;
        hp = maxHp;
        strenght = maxStrenght;
        poisoned = false;

        //set fruits
        fruits = new int[System.Enum.GetValues(typeof(Fruit)).Length];

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
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
}
