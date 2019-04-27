using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public SpriteRenderer[] options;




    public virtual void PlayerIsIn()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].enabled = true;
            options[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsIn();
        }
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
