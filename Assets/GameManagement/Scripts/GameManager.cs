using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    //game settings
    [Range(-80, 0)]
    public float mv;
    public static float masterVolume;
    public AudioMixer mainMixer;

    private void Awake()
    {
        //make object singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        masterVolume = mv;
        UpdateGameSettings();
    }

    //settings
    public void UpdateGameSettings()
    {
        mainMixer.SetFloat("MasterVolume", masterVolume);
    }
}
