using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{

    public int itemId;
    public Text priceText;
    public Text quantityText;
    public GameObject controller;
    int [,] upgradeItems;

    private void OnEnable()
    {
        controller = GameObject.FindWithTag("GameController");
        upgradeItems = controller.GetComponent<LevelController>().upgradeItems;
        priceText.text = (upgradeItems[2, itemId]).ToString();
        quantityText.text = (upgradeItems[3, itemId]).ToString();
    }
}
