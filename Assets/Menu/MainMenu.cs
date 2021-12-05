using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour{
    public static int saveNumber;
    public TextMeshProUGUI health1;
    public TextMeshProUGUI coins1;
    public TextMeshProUGUI health2;
    public TextMeshProUGUI coins2;
    public TextMeshProUGUI health3;
    public TextMeshProUGUI coins3;
    public TextMeshProUGUI world1;
    public TextMeshProUGUI world2;
    public TextMeshProUGUI world3;


    
    
    public void playGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame() {
        Application.Quit();
    }
    public void load() {
        MainMenu.saveNumber = 0;
        PlayerData data = SaveSystem.loadPlayer();
        health1.text = data.health.ToString();
        coins1.text = data.coins.ToString();
        MainMenu.saveNumber = 1;
        data = SaveSystem.loadPlayer();
        health2.text = data.health.ToString();
        coins2.text = data.coins.ToString();
        MainMenu.saveNumber = 2;
        data = SaveSystem.loadPlayer();
        health3.text = data.health.ToString();
        coins3.text = data.coins.ToString();

    }
    public void firstSave() {
        MainMenu.saveNumber = 0;
    }
    public void secondSave() {
        MainMenu.saveNumber = 1;
    }
    public void thirdSave() {
        MainMenu.saveNumber = 2;
    }
}
