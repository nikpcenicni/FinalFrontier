using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGameCollider : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void OnTriggerEnter2D() {
        if (player.level == "Red Planet")
            SceneManager.LoadScene("RedPlanet");
        if (player.level == "Forest Planet")
            SceneManager.LoadScene("ForestPlanet");
    }
}
