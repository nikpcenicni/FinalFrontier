using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenuUI;
    Rigidbody2D rb;
    GameObject door1;
    GameObject door2;
    GameObject door3;
    GameObject door4;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.E)) {

            }
        

    }

}
