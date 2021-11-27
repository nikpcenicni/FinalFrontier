using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platform : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void OnCollisionEnter2D (Collision2D col){
        if(col.gameObject.name.Equals("Player")){
            StartCoroutine(DropPlatform());
            Destroy(gameObject, 7f);
        }
    }

    IEnumerator DropPlatform(){
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        float t = 0f;
        float speed = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / 1f;
            speed = t * 3.71f;
            rb.velocity = new Vector2(0f, -speed);
            yield return null;
        }
    }
}
