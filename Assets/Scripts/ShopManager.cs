using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour{

    public int[,] shopItems = new int[3,6];
    public bool[] ownedGuns = new bool[3];

    public Player player;
    public GameObject weaponSwitch;


    // Start is called before the first frame update
    void Start()
    {
        //item num
        shopItems[0 , 0] = 0;
        shopItems[0 , 1] = 1;
        shopItems[0 , 2] = 2;
        shopItems[0 , 3] = 3;
        shopItems[0 , 4] = 4;
        shopItems[0 , 5] = 5;

        //price
        shopItems[1 , 0] = 5;
        shopItems[1 , 1] = 30;
        shopItems[1 , 2] = 100;
        shopItems[1 , 3] = 5;
        shopItems[1 , 4] = 30;
        shopItems[1 , 5] = 100;

        //damge
        shopItems[2 , 0] = 5;
        shopItems[2 , 1] = 20;
        shopItems[2 , 2] = 50;

        //quanity
        shopItems[2 , 3] = 0;
        shopItems[2 , 4] = 0;
        shopItems[2 , 5] = 0;
    }

    // Update is called once per frame
    public void Buy() {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;
        
        if (player.coins >= shopItems[1, itemID]){
            if (itemID >= 0 && itemID < 3) {
                if (!player.weapons[itemID]){
                    player.weapons[itemID] = true;
                    Debug.Log("player Weapons added");
                    player.coins -= shopItems[1, itemID];
                    shopItems[1, itemID] = 0;
                }else {
                    Debug.Log("already Owned");
                }
                
            } else if (itemID > 2 && itemID < 6){
                shopItems[2, itemID]++;
                player.coins -= shopItems[1, itemID];
            }
        }
    }
}
