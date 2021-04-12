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
    private GameObject controller;
    public int[,] upgradeItems;

    private void OnEnable()
    {
        controller = GameObject.FindWithTag("GameController");
        coins = controller.GetComponent<LevelController>().coins;
        coinsText.text = ("Coins: " + coins.ToString());
    }


    public void Buy() {

        GameObject UpgradeItemRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int itemId = UpgradeItemRef.GetComponent<UpgradeItem>().itemId;
        upgradeItems = controller.GetComponent<LevelController>().upgradeItems;
        if (upgradeItems[3, itemId] < 5)
        {
            if (coins >= upgradeItems[2, itemId])
            {
                coins -= upgradeItems[2, itemId];
                coinsText.text = "Coins: " + coins.ToString();

                upgradeItems[3, itemId]++;
                upgradeItems[2, itemId] +=10;

                controller.GetComponent<LevelController>().coins = coins;
                controller.GetComponent<LevelController>().upgradeItems = upgradeItems;

                UpgradeItemRef.GetComponent<UpgradeItem>().quantityText.text = upgradeItems[3, itemId].ToString();
                UpgradeItemRef.GetComponent<UpgradeItem>().priceText.text = upgradeItems[2, itemId].ToString();


            }
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
