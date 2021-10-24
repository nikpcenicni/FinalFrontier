using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;



public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[4,10];
    public int[] ownedGuns = new int[4];

    public Player player;
    public GameObject weaponSwitch;


    // Start is called before the first frame update
    void Start()
    {
        //item num
        shopItems[1 , 1] = 1;
        shopItems[1 , 2] = 2;
        shopItems[1 , 3] = 3;
        shopItems[1 , 4] = 4;
        shopItems[1 , 5] = 5;
        shopItems[1 , 6] = 6;
        shopItems[1 , 7] = 7;
        shopItems[1 , 8] = 8;
        shopItems[1 , 9] = 9;

        //price
        shopItems[2 , 1] = 5;
        shopItems[2 , 2] = 30;
        shopItems[2 , 3] = 100;
        shopItems[2 , 4] = 5;
        shopItems[2 , 5] = 30;
        shopItems[2 , 6] = 100;

        //damge
        shopItems[3 , 1] = 5;
        shopItems[3 , 2] = 20;
        shopItems[3 , 3] = 50;

        //quanity
        shopItems[3 , 4] = 0;
        shopItems[3 , 5] = 0;
        shopItems[3 , 6] = 0;

        ownedGuns[0] = 0;
        ownedGuns[1] = 0;
        ownedGuns[2] = 0;
        ownedGuns[3] = 0;


    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        
        // if ( ButtonRef.GetComponent<ButtonInfo>().ItemID < 4 && ButtonRef.GetComponent<ButtonInfo>().ItemID > 0)
        // {
        //     if (ownedGuns[ButtonRef.GetComponent<ButtonInfo>().ItemID] != null){
        //         if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 1)
        //             weaponSwitch.pistol();
        //         else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
        //             weaponSwitch.pistol();
        //         else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 3)
        //             weaponSwitch.pistol();
        //         else{
        //             weaponSwitch.Fist();
        //         }
                    
        //     }
        // }
        if (player.coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]){

            player.coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            if (ButtonRef.GetComponent<ButtonInfo>().ItemID > 0 && ButtonRef.GetComponent<ButtonInfo>().ItemID <= 3)
                ownedGuns[ButtonRef.GetComponent<ButtonInfo>().ItemID] = 1;
            if (ButtonRef.GetComponent<ButtonInfo>().ItemID >= 4 && ButtonRef.GetComponent<ButtonInfo>().ItemID <= 7)
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
        }
    }

    public void Owned(int itemNum, int quanity) {
        ownedGuns[itemNum] = quanity;
     }
}
