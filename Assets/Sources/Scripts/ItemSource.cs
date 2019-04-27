using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSource : Interaction {

    public Item item;
    public enum Item { Water, Manure}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerIsIn();
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
