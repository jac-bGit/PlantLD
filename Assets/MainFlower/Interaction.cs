using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public SpriteRenderer[] options;
    public PlayerBehaviour player;


    public virtual void PlayerIsIn()
    {
        if(options.Length == 1)
        {
            options[0].enabled = true;
            options[0].GetComponent<BoxCollider2D>().enabled = true;

        }
        else
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (player.water == 0 && player.manure == 0)
                {
                    options[i].enabled = false;
                    options[i].GetComponent<BoxCollider2D>().enabled = false;
                }
                else if (player.water == 0)
                {
                    options[0].enabled = true;
                    options[0].GetComponent<BoxCollider2D>().enabled = true;
                    options[1].enabled = false;
                    options[1].GetComponent<BoxCollider2D>().enabled = false;

                }
                else if (player.manure == 0)
                {
                    options[1].enabled = true;
                    options[1].GetComponent<BoxCollider2D>().enabled = true;
                    options[0].enabled = false;
                    options[0].GetComponent<BoxCollider2D>().enabled = false;

                }
                else
                {
                    options[i].enabled = true;
                    options[i].GetComponent<BoxCollider2D>().enabled = true;
                }

            }
        }
        
        
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsIn();
        }
    }


    public virtual void Update()
    {
        //if (player.manure == 0 && options.Length != 1)
        //{
        //    options[0].enabled = false;
        //    options[0].GetComponent<BoxCollider2D>().enabled = false;
        //}
        //else if (player.water == 0 && options.Length != 1)
        //{
        //    options[1].enabled = false;
        //    options[1].GetComponent<BoxCollider2D>().enabled = false;
        //}
    }
   

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].enabled = false;
                options[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
