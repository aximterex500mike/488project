using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    
    public int ItemID;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;

    //

    // each panel has two/one buttons for an upgrade

    public GameObject ItemManager;
    public Text priceText;

    // Update is called once per frame
    void Update() {

        //PriceText.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        //QuantityText.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();

    }
}
