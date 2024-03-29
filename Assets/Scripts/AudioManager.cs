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
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
        }
    }
    
    public void Play(string name) {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) {
             Debug.LogError($"Sound '{name}' not found in AudioManager!");
            return;
        }
        Debug.Log($"Playing sound: {name}");
        if(name == "Battle") {
            sound.source.loop = true;
        }
        sound.source.Play();
    }
}
