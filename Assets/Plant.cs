using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interaction
{
    //Stats Flower
    public int Water = 0;
    public int Manure = 0;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public override void PlayerIsIn()
    {
        base.PlayerIsIn();

    }

}
