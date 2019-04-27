using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlant : Interaction
{

    public static int Level = 1;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public override void PlayerIsIn()
    {
        base.PlayerIsIn();

    }


}
