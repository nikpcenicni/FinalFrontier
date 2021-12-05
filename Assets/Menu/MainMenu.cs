using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour{
    public static int saveNumber;
    public TextMeshProUGUI health1;
    public Image heart1;
    public TextMeshProUGUI coins1;
    public Image moonRock1;
    public TextMeshProUGUI health2;
    public Image heart2;
    public TextMeshProUGUI coins2;
    public Image moonRock2;
    public TextMeshProUGUI health3;
    public Image heart3;
    public TextMeshProUGUI coins3;
    public Image moonRock3;
    public TextMeshProUGUI newGame1;
    public TextMeshProUGUI newGame2;
    public TextMeshProUGUI newGame3;
    public int saveFlag1;
    public int saveFlag2;
    public int saveFlag3;

    public void redPlanet(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void forestPlanet(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    public void endless(){
        
    }
    public void playGame1() {
        if(saveFlag1 == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void playGame2() {
        if(saveFlag2 == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void playGame3() {
        if(saveFlag3 == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void quitGame() {
        Application.Quit();
    }
    public void load() {
        newGame1.enabled = false;
        newGame2.enabled = false;
        newGame3.enabled = false;
        
        MainMenu.saveNumber = 0;
        PlayerData data = SaveSystem.loadPlayer();
        if(data == null){
            newGame1.enabled = true;
            moonRock1.enabled = false;
            heart1.enabled = false;
            saveFlag1 = 0;
        } else {
            health1.text = data.health.ToString();
            coins1.text = data.bank.ToString();
            saveFlag1 = 1;
        }
        
        MainMenu.saveNumber = 1;
        PlayerData data1 = SaveSystem.loadPlayer();
        if(data1 == null){
            newGame2.enabled = true;
            moonRock2.enabled = false;
            heart2.enabled = false;
            saveFlag2 = 0;
        } else{
            health2.text = data1.health.ToString();
            coins2.text = data1.bank.ToString();
            saveFlag2 = 1;
        }

        MainMenu.saveNumber = 2;
        PlayerData data2 = SaveSystem.loadPlayer();
        if(data2 == null){
            newGame3.enabled = true;
            moonRock3.enabled = false;
            heart3.enabled = false;
            saveFlag3 = 0;
        } else {
            health3.text = data2.health.ToString();
            coins3.text = data2.bank.ToString();
            saveFlag3 = 1;
        }
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
