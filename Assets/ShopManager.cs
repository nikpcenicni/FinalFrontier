using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;



public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[10,10]; 

    public Player player;


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
        shopItems[2 , 7] = 5;
        shopItems[2 , 8] = 30;
        shopItems[2 , 9] = 100;

        //damge
        shopItems[3 , 1] = 5;
        shopItems[3 , 2] = 20;
        shopItems[3 , 3] = 50;

        //quanity
        shopItems[3 , 4] = 0;
        shopItems[3 , 5] = 0;
        shopItems[3 , 6] = 0;

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (player.coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]){

            player.coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
        }
    }
}
