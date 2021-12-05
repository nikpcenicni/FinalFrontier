using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class IntoductionText : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string[] phrases = new string[1];
    public int phraseCounter = 0;

    void Start(){
        textBox.SetText(phrases[0]);
    }
    public void nextPhrase(){
        phraseCounter++;
        if (phraseCounter < phrases.Length)
            textBox.SetText(phrases[phraseCounter]);  
    }
    public void loadMenu(){
        if(phraseCounter == 8){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void loadBoss1(){
        if(phraseCounter == 10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void loadBoss2(){
        if(phraseCounter == 8){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
     public void loadLevel2(){
        if(phraseCounter == 8){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
