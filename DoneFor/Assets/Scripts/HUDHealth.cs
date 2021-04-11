using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDHealth : MonoBehaviour
{
    public static int HealthVal = 0;
    Text Health;
    void Start()
    {
        Health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + HealthVal;
    }
}
