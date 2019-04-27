using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Audio[] audios;


    private void Awake()
    {
        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
            a.source.mute = a.mute;
        }
    }

    public void Play(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.LogError(name + "not found in audio clips");
            return;
        }
        a.source.Play();
    }
}
