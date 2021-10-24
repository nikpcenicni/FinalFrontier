using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;


    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];
        for (int i = 0; i < totalWeapons; i++) {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    public void fist(){
        for (int i = 0; i < totalWeapons; i++) {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
    }
    public void pistol(){
        fist();
        guns[1].SetActive(true);
    }
    public void LaserRifle(){
        fist();
        guns[2].SetActive(true);
    }
    public void PlasmaRifle(){
        fist();
        guns[3].SetActive(true);
    }
}
