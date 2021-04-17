using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
   
    public AudioManager audioManager;

    public void SetVolume(float volume) {
        audioManager.SetVolume(volume);
    }

}
