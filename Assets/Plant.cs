using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interaction
{
    //Stats Flower

    public float WaterTime = 1;
    public float Water = 0;
    public float MaxWater = 0;

    public float ManureTime = 1;
    public float Manure = 0;
    public float MaxManure = 0;

    public float FruitSize = 1;
    public float FruitMax = 2;

    bool Growing = false;


    public Transform Fruit;
    public Transform WaterUI;
    public Transform ManureUI;
   

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


        if(options.Length != 1)
        {

            if (FruitSize < FruitMax)
            { 
                FruitGrow();
            }
           
            
            
                 
                WaterUI.localScale = new Vector3(Water, 0.1f,1);
                ManureUI.localScale = new Vector3(Manure, 0.1f, 1);
                Fruit.localScale = new Vector3(FruitSize, FruitSize, FruitSize);
                
        }
    
        

    }

    public IEnumerator StartCountdownWater()
    {
       
        Water = MaxWater;

        while (Water > 0f)
        {
            
            yield return new WaitForSeconds(1f);
            Water -= WaterTime;
        }
    }

    public IEnumerator StartCountdownManure()
    {

        Manure = MaxManure;

        while (Manure > 0f)
        {
            
            yield return new WaitForSeconds(1.0f);
            Manure -= ManureTime;
        }
    }

    public IEnumerator Grouwing()
    {
        
        while (FruitSize <= FruitMax)
        {
            yield return new WaitForSeconds(1.0f);
            FruitSize += 0.01f; 
            if(FruitSize == FruitMax)
            {
                break;
            }
        }
       
        
    }

    public void FruitGrow()
    {
        if(Manure > 0 && Water > 0)
        {   
            StartCoroutine(Grouwing());
        }
      

    }
    public void CountDownWater()
    {
        StartCoroutine(StartCountdownWater());
    }

    public void CountDownManure()
    {
        StartCoroutine(StartCountdownManure());
    }








}
