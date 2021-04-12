using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// public class WeaponUpgrade {

//     int[,] upgrade = new int[3,3];

//     // upgrade[i][j]

//     // upgrade[0][0] = firerate multiplier
//     // upgrade[1][0] = damage multipler

//     // upgrade[0][1] = firerate upgrade cost
//     // upgrade[1][1] = damage upgrade cost

//     public WeaponUpgrade(int fireRate, int damage, int fireRate_quantity, int damage_quantity) {
//         this.upgrade[0,0] = fireRate;
//         this.upgrade[1,0] = damage;

//         this.upgrade[0,1] = 10;
//         this.upgrade[1,1] = 10;

//         this.upgrade[0, 2] = fireRate_quantity;
//         this.upgrade[1, 2] = damage_quantity;

//     }
// }

// public class PlayerUpgrade {

//     int health_upgrade = 0;
//     int health_quantity = 0;

//     public PlayerUpgrade(int health_upgrade, int health_quantity) {
//         this.health_upgrade = health_upgrade;
//         this.health_quantity = health_quantity;
//     }
// }

// public class BombUpgrade {
//     int[,] upgrade = new int[3,3];
    
//     // upgade[i][j]
//     //
//     // upgrade[0][0] = bomb damage multiplier
//     // upgrade[1][0] = bomb radius multiplier

//     // upgrade[0][1] = bomb damage cost
//     // upgrade[1][1] = bomb radius cost

//     public BombUpgrade(int damage, int radius, int damage_quantity, int radius_quantity) {
//         this.upgrade[0,0] = damage;
//         this.upgrade[1,0] = radius;

//         this.upgrade[0,1] = 10;
//         this.upgrade[1,1] = 10;

//         this.upgrade[0,2] = damage_quantity;
//         this.upgrade[1,2] = radius_quantity;
//     }
// }

// public class Upgrades {

//     int[,] weapon = new int[3,3];
//     int[,] player = new int[3,3];
//     int[,] bomb = new int[3,3];

//     Upgrades(int[,] weapon, int[,] player, int[,] bomb) {

//     }

// }


public class ItemManagerScript : MonoBehaviour
{
    public int coins;   // coins that will be loaded in from GameObject
    public Text coinsText;

    // public WeaponUpgrade weaponUpgrade; // loaded in from GameObject
    // public PlayerUpgrade playerUpgrade;
    // public BombUpgrade bombUpgrade;

    private GameObject controller;

    public int[,] upgradeItems = new int[4,7];


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GameController");

        coinsText.text = "Coins: " + coins.ToString();

        // data should be loaded in from Player gameObject
        // weaponUpgrade = new WeaponUpgrade(0, 0, 0);
        // playerUpgrade = new PlayerUpgrade(0, 0);
        // bombUpgrade = new BombUpgrade(0, 0, 0);

        // ID's = upgradeItems[1,i]
        upgradeItems[1,1] = 1;  // revolver firerate
        upgradeItems[1,2] = 2;  // revolver dmg
        upgradeItems[1,3] = 3;  // shotgun firerate
        upgradeItems[1,4] = 4;  // shotgun dmg
        upgradeItems[1,5] = 5;  // bomb radius
        upgradeItems[1,6] = 6;  // bomb count
        upgradeItems[1,7] = 7;  // player health

        // Price = upgradeItems[2,i]
        upgradeItems[2,1] = 10;
        upgradeItems[2,2] = 10;
        upgradeItems[2,3] = 10;
        upgradeItems[2,4] = 10;
        upgradeItems[2,5] = 10;
        upgradeItems[2,6] = 10;
        upgradeItems[2,7] = 10;

        // Quantity = upgradeItems[3,i]
        upgradeItems[3,1] = 0;
        upgradeItems[3,2] = 0;
        upgradeItems[3,3] = 0;
        upgradeItems[3,4] = 0;
        upgradeItems[3,5] = 0;
        upgradeItems[3,6] = 0;
        upgradeItems[3,7] = 0;

    }


    public void Buy() {

        GameObject UpgradeItemRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int itemId = UpgradeItemRef.GetComponent<UpgradeItem>().itemId;

        if(coins >= upgradeItems[2, itemId]) {
            coins -= upgradeItems[2, itemId];
            upgradeItems[3, itemId]++;
            coinsText.text = "Coins: " + coins.ToString();
            UpgradeItemRef.GetComponent<UpgradeItem>().quantityText.text = upgradeItems[3, itemId].ToString();
        }


        // if(itemId == 1 || itemId == 2) {
        //     // weaponUpgrade
        //     if(itemId == 1) {
        //         // firerate
                

        //     } else {
        //         // dmg
        //     }

        // } else if(item == 3) {
        //     // PlayerUpgrade

        // } else if(item == 4 || itemId == 5) {
            
        //     // BombUpgrade
        //     if(itemId == 4) {
        //         // dmg
        //     } else {
        //         // radius
        //     }

        // }

    }
}
