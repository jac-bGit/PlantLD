using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : Usable {

    //basics
    public int maxWater, water;
    public int maxManure, manure;
    //growing
    [Header("--GROWING--")]
    public GameObject fruitGo;
    private GameObject fruit;
    public PlayerBehaviour.Fruit fruitType;
    public Transform fruitPos;
    private Animator fruitAnim;
    private ParticleSystem fruitParticles;
    public float minSize, maxSize;
    public float growState, growTime;
    public bool grown;

    //bars
    public GameObject waterBar, manureBar;

    private PlayerBehaviour player;

	// Use this for initialization
	void Start () {
        OnStart();

        water = 0;
        manure = 0;
        growState = 0;
        grown = false;

        player = FindObjectOfType<PlayerBehaviour>();
        fruitAnim = fruitPos.GetComponent<Animator>();
        fruitParticles = fruitPos.GetComponent<ParticleSystem>();

        //spawn fruit
        fruit = Instantiate(fruitGo, fruitPos.position, fruitPos.rotation, fruitPos);

        //start courutines
        StartCoroutine(FruitGrowing());
        StartCoroutine(Needs());
    }
	
	// Update is called once per frame
	void Update () {
        OnUpdate();

        Fruit();
        Bars();

        //fix
        if (manure > maxManure)
            manure = maxManure;
        if (water > maxWater)
            water = maxWater;
    }


    //fruit growing
    void Fruit()
    {
        if (growState < 1)
        {

            float size = (maxSize - minSize) * growState;
            fruit.transform.localScale = new Vector3(size, size, size);
        }
        else
        {
            fruitPos.GetComponent<ParticleSystem>().Play(false);
        }

        if (growState >= 1)
            grown = true;
        else
            grown = false;

        //growing state
        if (grown)
        {
            fruitParticles.Stop(true);
        }
        else
        {
            if (water > 0 && manure > 0)
            {
                if (!fruitParticles.isPlaying)
                {
                    fruitParticles.Play(true);
                }
            }
            else
                fruitParticles.Stop(true);
        }

        //active animation
        fruitAnim.SetBool("Grown", grown);
    }

    IEnumerator FruitGrowing()
    {
        while (true)
        {
            if (water > 0 && manure > 0)
            {
                if (growState < 1)
                    growState += 0.01f;
            }
            yield return new WaitForSeconds(growTime / 100);
        }
    }

    //actions
    public void AddWater() {
        if (player.water > 0)
        {
            water = maxWater; player.water--;
        }
    }
    public void AddManure() {
        if (player.manure > 0)
        {
            manure = maxManure; player.manure--;
        }
    }
    public void HarvestFruit() {
        if (growState >= 1)
        {
            player.fruits[(int)fruitType] += 1; growState = 0;
        }
    }


    public void OnTriggerStay2D(Collider2D col)
    {
        TriggerEnter(col);
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        TriggerExit(col);
    }

    //substract need
    IEnumerator Needs()
    {
        while (true)
        {
            if (water > 0)
                water--;
            if (manure > 0)
                manure--;

            yield return new WaitForSeconds(1);
        }
    }

    //bars
    void Bars()
    {
        Vector3 watBarScale = manureBar.transform.localScale;
        float watFill = (float)water / (float)maxWater;
        waterBar.transform.localScale = new Vector3(watFill, watBarScale.y, watBarScale.z);
        Vector3 manBarScale = manureBar.transform.localScale;
        float manFill = (float)manure / (float)maxManure;
        manureBar.transform.localScale = new Vector3(manFill, manBarScale.y, manBarScale.z);
    }
}
