using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningInfo : MonoBehaviour
{

    public Text error;

    public GameObject ShopManager;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        error.text = ShopManager.GetComponent<ShopManager>().error;
    }
}
