using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixed : MonoBehaviour
{
    public Transform target;
    float step;
    float originalStep;
    float originalSpeed;
    Vector2 screenBounds;
    Vector2 screenOrigo;
    Vector3 originalPosition;
    Vector3 originalPos;
    int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        step = 3f;
        originalStep = step;
        originalSpeed = GameObject.Find("Player").GetComponent<Player>().speed;
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        originalPos = new Vector3(GameObject.Find("Player").GetComponent<Player>().rb.transform.position.x, GameObject.Find("Player").GetComponent<Player>().rb.transform.position.y, GameObject.Find("Player").GetComponent<Player>().rb.transform.position.z);
        playerHealth = GameObject.Find("Player").GetComponent<Player>().currentHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);
        if (target.position.x > screenBounds.x || target.position.x < screenOrigo.x)
        {
            GameObject.Find("Player").GetComponent<Player>().TakeDamage(1);
            GameObject.Find("Player").GetComponent<Player>().rb.transform.position = originalPos;
            transform.position = originalPosition;
            GameObject.Find("Player").GetComponent<Player>().speed = originalSpeed;
            step = originalStep;
        }
        if (GameObject.Find("Player").GetComponent<Player>().currentHealth < playerHealth) {
            GameObject.Find("Player").GetComponent<Player>().rb.transform.position = originalPos;
            transform.position = originalPosition;
            GameObject.Find("Player").GetComponent<Player>().speed = originalSpeed;
            step = originalStep;
        }
        playerHealth = GameObject.Find("Player").GetComponent<Player>().currentHealth;
        var cameraPosition = transform.position;
        cameraPosition.x += step * Time.deltaTime;
        transform.position = cameraPosition;
        GameObject.Find("Player").GetComponent<Player>().speed = GameObject.Find("Player").GetComponent<Player>().speed + (1 * Time.deltaTime);
        step = step + (1 * Time.deltaTime);
    }
}
