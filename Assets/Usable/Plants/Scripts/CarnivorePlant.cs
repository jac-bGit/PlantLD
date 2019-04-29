using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorePlant : Usable {

    [Header("--PLANT--")]
    public float feedTime;
    public int level, levelsToSecondStage;
    private int maxLevels;
    public GameObject plants, stage1, stage2;
    public bool feeding;
    [Header("--LEVELS--")]
    public PlantLevel[] levels;

    public Animator anim;

    private PlayerBehaviour player;

	// Use this for initialization
	void Start () {
        OnStart();
        level = 0;
        anim = stage1.GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerBehaviour>();
        feeding = false;
        maxLevels = levels.Length;
        //set
        feedTime = levels[level].feedTime;
        float scale = levels[level].size;
        plants.transform.localScale = new Vector3(scale, scale, scale);

        StartCoroutine(FeedTiming());
    }
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
        Rotating();
        ChangeStages();

        //lose
        if (feedTime <= 0)
            PlayerBehaviour.gameplayState = PlayerBehaviour.GameplayState.Lose;
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        TriggerEnter(col);
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        TriggerExit(col);
    }

    //stages
    void ChangeStages()
    {
        if (level >= levelsToSecondStage)
        {
            stage1.SetActive(false);

            if (stage2.activeSelf == false)
            {
                anim = stage2.GetComponentInChildren<Animator>();
                stage2.SetActive(true);
            }
        }
        else
        {
            stage1.SetActive(true);
            stage2.SetActive(false);
            anim = stage1.GetComponentInChildren<Animator>();
        }
    }

    public void Rotating()
    {
        if (player.transform.position.x > transform.position.x)
        {
            float scale1 = Mathf.Abs(stage1.transform.localScale.x);
            stage1.transform.localScale = new Vector2(scale1, stage1.transform.localScale.y);
            float scale2 = Mathf.Abs(stage2.transform.localScale.x);
            stage2.transform.localScale = new Vector2(scale2, stage1.transform.localScale.y);
        }
        else
        {
            float scale1 = -Mathf.Abs(stage1.transform.localScale.x);
            stage1.transform.localScale = new Vector2(scale1, stage1.transform.localScale.y);
            float scale2 = -Mathf.Abs(stage2.transform.localScale.x);
            stage2.transform.localScale = new Vector2(scale2, stage1.transform.localScale.y);
        }
    }

    public void Attack()
    {
        if(!feeding)
            StartCoroutine("Bitting");
    }

    IEnumerator Bitting()
    {
        anim.SetBool("Bite", true);
        feeding = true;
        yield return new WaitForSeconds(1f);
        //sebstract player stats
        player.hp -= levels[level].hpDmg;
        player.speed -= levels[level].speedDmg;
        player.strenght -= levels[level].strenghtDmg;
        if (levels[level].poisoned == true)
            player.poisoned = true;
        anim.SetBool("Bite", false);

        yield return new WaitForSeconds(2);
        //level up
        level++;
        feedTime = levels[level].feedTime;
        float scale = levels[level].size;
        plants.transform.localScale = new Vector3(scale, scale, scale);
        feeding = false;
        StopCoroutine("Bitting");
    }

    IEnumerator FeedTiming()
    {
        while (true)
        {
            if (!feeding && feedTime > 0) {
                feedTime--;
            }
            yield return new WaitForSeconds(1);
        }
    }
}

[System.Serializable]
public class PlantLevel
{
    public float size;
    public float feedTime;
    public int hpDmg;
    public int speedDmg;
    public int strenghtDmg;
    public bool poisoned;
}
