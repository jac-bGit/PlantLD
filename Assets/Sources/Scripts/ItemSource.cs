using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSource : Usable {

    public Item item;
    public enum Item { Water, Manure}


	// Use this for initialization
	void Start () {
        OnStart();
    }
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
    }


    public void OnTriggerStay2D(Collider2D col)
    {
        TriggerEnter(col);
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        TriggerExit(col);
    }

    //add source
    public void TakeSource()
    {
        PlayerBehaviour pb = FindObjectOfType<PlayerBehaviour>();

        //add item
        if (pb.itemsCount() < pb.strenght)
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
