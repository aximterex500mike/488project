using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public static bool nextPress;
    public static bool prevPress;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {

            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        WeaponHUDScript.weaponName = currentGun.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextPress  == true)
        {
            //next Weapon
            if(currentWeaponIndex < totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                WeaponHUDScript.weaponName = currentGun.name;
                nextPress = false;
            }
            else{
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 0;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                WeaponHUDScript.weaponName = currentGun.name;
                nextPress = false;  
            }

        }

        if (prevPress  == true)
        {
            //previous Weapon            
            if(currentWeaponIndex >= 0){
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                if(currentWeaponIndex > -1){
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                WeaponHUDScript.weaponName = currentGun.name;
                prevPress = false;  }
            }
            if (currentWeaponIndex < 0)
            {
                guns[0].SetActive(false);
                guns[2].SetActive(true);
                currentGun = guns[2];
                WeaponHUDScript.weaponName = currentGun.name;
                prevPress = false; 
                currentWeaponIndex = 2;
            
            }

        }
    } 
    }
