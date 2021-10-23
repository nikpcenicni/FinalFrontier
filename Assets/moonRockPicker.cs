using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moonRockPicker : MonoBehaviour
{
    private float coin = 000;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other ){
        if(other.transform.tag == "moonRock"){
            coin ++;
            if (coin < 10) 
                textCoins.text = "00" + coin.ToString();
            else if (coin < 100 && coin >= 10) 
                textCoins.text = "0" + coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
