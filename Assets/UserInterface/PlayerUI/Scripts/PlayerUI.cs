using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    //player
    private PlayerBehaviour player;

    //ui elements
    public Text txtHp;
    public Slider sliderHp;
    public Text txtWater;
    public Text txtManure;
    public Text txtItems;
    [Header("Fruits")]
    public Text txtHpFruit;
    public Text txtSpeedFruit;
    public Text txtStrenghtFruit;
    public Text txtAntidoteFruit;

    // Use this for initialization
    void Start () {
        //get player
        player = FindObjectOfType<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {

        //show stats in ui
        txtHp.text = player.hp + " / " + player.maxHp;
        sliderHp.value = (float)player.hp / (float)player.maxHp;
        txtWater.text = player.water.ToString();
        txtManure.text = player.manure.ToString();
        txtItems.text = player.itemsCount().ToString() + " / " + player.strenght;
        //fruits count
        txtHpFruit.text = player.fruits[(int)PlayerBehaviour.Fruit.Hp].ToString();
        txtSpeedFruit.text = player.fruits[(int)PlayerBehaviour.Fruit.Speed].ToString();
        txtStrenghtFruit.text = player.fruits[(int)PlayerBehaviour.Fruit.Strenght].ToString();
        txtAntidoteFruit.text = player.fruits[(int)PlayerBehaviour.Fruit.Antidote].ToString();
    }

    //on fruit click
    public void HpFruit()
    {
        if (player.fruits[(int)PlayerBehaviour.Fruit.Hp] > 0 && player.hp < player.maxHp)
        {
            player.hp += (int)((float)player.maxHp * 0.25f);
            player.fruits[(int)PlayerBehaviour.Fruit.Hp]--;
        }
    }

    public void SpeedFruit()
    {
        if (player.fruits[(int)PlayerBehaviour.Fruit.Speed] > 0 && player.speed < player.maxSpeed)
        {
            player.speed = player.maxSpeed;
            player.fruits[(int)PlayerBehaviour.Fruit.Speed]--;
        }
    }

    public void StrenghtFruit()
    {
        if (player.fruits[(int)PlayerBehaviour.Fruit.Strenght] > 0 && player.strenght < player.maxStrenght)
        {
            player.strenght = player.maxStrenght;
            player.fruits[(int)PlayerBehaviour.Fruit.Strenght]--;
        }
    }

    public void AntidoteFruit()
    {
        if (player.fruits[(int)PlayerBehaviour.Fruit.Antidote] > 0 && player.poisoned)
        {
            player.poisoned = false;
            player.fruits[(int)PlayerBehaviour.Fruit.Antidote]--;
        }
    }
}
