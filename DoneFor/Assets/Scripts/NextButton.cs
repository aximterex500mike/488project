using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
     public static bool nextPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextButton(){
     nextPressed = true;
     WeaponSelect.nextPress = nextPressed;
    }
}
