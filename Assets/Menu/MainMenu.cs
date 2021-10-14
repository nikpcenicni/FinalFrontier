using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    public static int saveNumber;
    
    public void playGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame() {
        Application.Quit();
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
