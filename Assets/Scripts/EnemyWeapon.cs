using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    float lastTimeShot;
    public Transform firePoint;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        lastTimeShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeShot > 2f) {
            Shoot();
            lastTimeShot = Time.time;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
