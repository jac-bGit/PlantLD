using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {


    public Plant value;
    public PlayerBehaviour player;
    public MainPlant mainPlant;

   public enum Action
    {
        feed,water,powerUp,addFeed,addWater,Grab
    }

    public Action Controler;

    private void Update()
    {
        if (Controler == Action.water && player.water == 0 || Controler == Action.feed && player.manure == 0 || Controler == Action.Grab && value.GrowLevel != value.MaxGrowLevel)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(value != null && value.GrowLevel == value.MaxGrowLevel && Controler != Action.addWater && Controler != Action.addFeed && Controler != Action.powerUp )
        {
           
         if (Controler == Action.Grab)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Controler != Action.Grab)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }


        }
    }

    private void OnMouseDown()
    {
    
        if(Controler == Action.Grab)
        {
            value.PickUpFruit();
        }
        else if (Controler == Action.water && player.water != 0)
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
