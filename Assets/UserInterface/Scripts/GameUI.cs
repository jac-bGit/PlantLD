using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : UIController {

    public GameObject pauseMenu, loseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShowMenus();
	}

    void ShowMenus()
    {
        //pause menu
        if (PlayerBehaviour.gameplayState == PlayerBehaviour.GameplayState.Pause)
            pauseMenu.SetActive(true);
        else
            pauseMenu.SetActive(false);

        //lose menu
        if (PlayerBehaviour.gameplayState == PlayerBehaviour.GameplayState.Lose)
            loseMenu.SetActive(true);
        else
            loseMenu.SetActive(false);
    }

    public void Continue()
    {
        PlayerBehaviour.gameplayState = PlayerBehaviour.GameplayState.Playing;
    }
}
