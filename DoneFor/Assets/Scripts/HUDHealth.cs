using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDHealth : MonoBehaviour
{
    public static int HealthVal = 0;
    GameObject player;
    Text Health;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + player.GetComponent<Health>().hp;
    }
}
