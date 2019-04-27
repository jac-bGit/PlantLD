using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlant : Interaction
{


    public PowerUps[] stats;
    float timeLeft = 3.0f;
    public static int Level = 0;

    public override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
    }

    public override void PlayerIsIn()
    {
        base.PlayerIsIn();

    }

    private void Start()
    {
        Countdown(5f);
        
    }

    private IEnumerator Countdown(float duration)
    {

        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        Debug.Log("DEaD");
    }

        public void PowerUp()
    {
        if(Level != 9)
        {
            Level++;
            player.hp -= stats[Level].HpDamage;
            player.speed -= stats[Level].Slow;
            player.strenght -= stats[Level].LowerStrenght;
            player.poisoned = stats[Level].Poisoned;
        }
        else
        {
            Debug.Log("YOU WON ?");
        }
      
    }


}

[System.Serializable]
public class PowerUps 
{
    public int HpDamage;
    public int Slow;
    public int LowerStrenght;
    public bool Poisoned;
}
