using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds) {
            if (sound.source != null) {
                sound.source = gameObject.GetComponent<AudioSource>();
                sound.source.clip = sound.clip;

                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name) {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) {
             Debug.LogError($"Sound '{name}' not found in AudioManager!");
            return;
        }
        Debug.Log($"Playing sound: {name}");
        sound.source.Play();
    }
}
