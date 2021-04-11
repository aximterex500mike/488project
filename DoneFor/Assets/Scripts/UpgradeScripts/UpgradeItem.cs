using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{

    public int itemId;
    public Text priceText;
    public Text quantityText;
    public GameObject ItemManager;


    // Update is called once per frame
    void Update() {
        priceText.text = ItemManager.GetComponent<ItemManagerScript>().upgradeItems[2, itemId].ToString();
        quantityText.text = ItemManager.GetComponent<ItemManagerScript>().upgradeItems[3, itemId].ToString();
    }
}
