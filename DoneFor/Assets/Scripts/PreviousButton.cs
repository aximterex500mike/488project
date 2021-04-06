using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : MonoBehaviour
{
     public static bool prevPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrevButton(){
     prevPressed = true;
     WeaponSelect.prevPress = prevPressed;
    }
}
