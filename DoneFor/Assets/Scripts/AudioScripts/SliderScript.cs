using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public AudioManager audioManager;

    //public Slider slider;

    // Start is called before the first frame update
    void Start()
    {

        Slider slider = gameObject.GetComponent<Slider>();
        slider.value = audioManager.getVolume("Theme");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
