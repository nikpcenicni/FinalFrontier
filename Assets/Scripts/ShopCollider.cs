using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCollider : MonoBehaviour
{

    public GameObject shop;
    public GameObject shopError;

    void OnTriggerEnter2D() {
        shop.SetActive(true);
    }
    void OnTriggerExit2D() {
        shop.SetActive(false);
        shopError.SetActive(false);
    }
}
