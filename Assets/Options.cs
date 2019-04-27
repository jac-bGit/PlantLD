using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {


    public Plant value;
    
   public enum Action
    {
        feed,water,powerUp
    }

    public Action Controler;

    private void OnMouseDown()
    {
        if (Controler == Action.water)
        {
            value.Water++;

        }else if(Controler == Action.feed){

            value.Manure++;
          
        }
        else if (Controler == Action.powerUp)
        {
            MainPlant.Level++;
        }
        else
        {
            Debug.Log("Not defined Controler in: " + this.gameObject);
        }
        
    }
   
}
