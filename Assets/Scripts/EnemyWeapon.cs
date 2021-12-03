using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    float lastTimeShot;
    public Transform firePoint;

    public GameObject bulletPrefab;
    Vector2 screenBounds;
    Vector2 screenOrigo;
    // Start is called before the first frame update
    void Start()
    {
        lastTimeShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (Time.time - lastTimeShot > 2f && !(transform.position.x > screenBounds.x || transform.position.x < screenOrigo.x)) {
            Shoot();
            lastTimeShot = Time.time;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
