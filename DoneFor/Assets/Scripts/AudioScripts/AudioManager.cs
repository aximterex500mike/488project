using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    // Use this for all audio
    public Sound[] sounds;

    public static AudioManager instance;
    
    void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        Play("Theme");
    }


    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public float getVolume(string name) {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        return s.volume;
    }

    public void SetVolume(float volume) {
        string name = "Theme";
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = volume;
        s.setVolume(volume);
    }

    public void SetEffectVolume(float volume) {
        //string name = "Theme";
        Sound s1 = Array.Find(instance.sounds, sound => sound.name == "Revolver");
        Sound s2 = Array.Find(instance.sounds, sound => sound.name == "Shotgun");
        if (s1 == null || s2 == null) {
            Debug.LogWarning("Sound: " + s1.name + " not found!");
            return;
        }

        s1.source.volume = volume;
        s1.setVolume(volume);

        s2.source.volume = volume;
        s2.setVolume(volume);
    }
}
