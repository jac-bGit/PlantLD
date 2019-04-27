using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {


    public Plant value;
    public PlayerBehaviour player;
    public MainPlant mainPlant;

   public enum Action
    {
        feed,water,powerUp,addFeed,addWater
    }

    public Action Controler;

    private void Update()
    {
        if (Controler == Action.water && player.water == 0 || Controler == Action.feed && player.manure == 0)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
    

        if (Controler == Action.water && player.water != 0)
        {
            player.water--;
           
            value.CountDownWater();

        }else if(Controler == Action.feed && player.manure != 0){

            player.manure--;
           
            value.CountDownManure();
          
        }
        else if (Controler == Action.powerUp)
        {
            mainPlant.PowerUp();

        }else if (Controler == Action.addWater)
        {
            player.water++;

        }else if(Controler == Action.addFeed)
        {
            player.manure++;
        }
        else
        {
          
                Debug.Log("Not defined Controler in: " + this.gameObject);
            
          
        }
        
    }
   
}
