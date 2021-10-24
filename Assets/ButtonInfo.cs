using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public Text PriceTxt;
    public Text DmgText;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        DmgText.text = "Dmg: " + ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
        
        if (ItemID >= 4 && ItemID <= 7)
            DmgText.text = "Qty: " + ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
