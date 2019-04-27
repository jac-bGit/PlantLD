using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSource : MonoBehaviour {

    public Item item;
    public enum Item { Water, Manure}

    public int activated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //add source
    void TakeSource()
    {
        PlayerBehaviour pb = FindObjectOfType<PlayerBehaviour>();

        //add item
        if (pb.water + pb.manure < pb.strenght)
        {
            switch (item)
            {
                case Item.Manure:
                    pb.manure++;
                    break;
                case Item.Water:
                    pb.water++;
                    break;
            }
        }
    }
}
