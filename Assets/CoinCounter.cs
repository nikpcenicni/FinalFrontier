using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("ThePlayer").GetComponent<PlayerScript>().Health -= 10.0f;;
        coinText = gameObject.GetComponent<Text>();
        coinText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = GameObject.Find("Player").GetComponent<Player>().coins.ToString();;
        
   }
}
