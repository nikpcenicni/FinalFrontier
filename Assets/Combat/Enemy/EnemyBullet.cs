using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject shootingEnemy;
    public int damage = 5;
    Vector3 originalPos;
    //public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        originalPos = new Vector3(GameObject.Find("Player").GetComponent<Player>().rb.transform.position.x, GameObject.Find("Player").GetComponent<Player>().rb.transform.position.y, GameObject.Find("Player").GetComponent<Player>().rb.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            GameObject.Find("Player").GetComponent<Player>().rb.transform.position = originalPos;
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
