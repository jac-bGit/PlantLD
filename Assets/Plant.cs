using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interaction
{
    //Stats Flower
    public int Water = 0;
    public int Manure = 0;

    public override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
    }

    public override void PlayerIsIn()
    {
        base.PlayerIsIn();

    }

    public override void Update()
    {
        base.Update();
    }

}
