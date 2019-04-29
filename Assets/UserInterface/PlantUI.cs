using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantUI : MonoBehaviour {

    public Text txtFeedTime;

    public Slider timeBar;

    private CarnivorePlant plant;

	// Use this for initialization
	void Start () {
        plant = FindObjectOfType<CarnivorePlant>();
	}
	
	// Update is called once per frame
	void Update () {
        txtFeedTime.text = plant.feedTime.ToString();
        timeBar.value = plant.feedTime / plant.levels[plant.level].feedTime;
    }
}
