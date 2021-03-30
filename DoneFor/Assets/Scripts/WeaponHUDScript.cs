using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUDScript : MonoBehaviour
{
    public static string weaponName = "";
    Text Name;
    void Start()
    {
        Name = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = "Weapon: " + weaponName;
    }
}
