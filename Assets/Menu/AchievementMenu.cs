using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class AchievementMenu : MonoBehaviour
{
    public Graphic m_Graphic;
    public Color m_MyColor;
    public Text m_Text;
    public TMPro.TextMeshProUGUI m_TMProText;
    public bool[] achievementsUnlocked = new bool[9];
    public float[] achievementsProgress = new float[9];
    public GameObject pauseMenu;
    public GameObject deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        loadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeSelf && !deadMenu.activeSelf) {
            loadPlayer();
            setAchievementProgress();
            CheckAchievementUnlocked();
        }
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();

        for (int i = 0; i < achievementsUnlocked.Length; i++)
        {
            achievementsUnlocked[i] = data.achievementsUnlocked[i];
        }
        for (int i = 0; i < achievementsProgress.Length; i++)
        {
            achievementsProgress[i] = data.achievementsProgress[i];
        }
    }

    public void setAchievementProgress() {
        /*
        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[0].ToString() + " / ?";
        */

        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[1].ToString() + " / 100";

        /*
        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[2].ToString() + " / ?";

        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[3].ToString() + " / ?";

        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[4].ToString() + " / ?";

        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = achievementsProgress[5].ToString() + " / ?";
        */

        float distance;
        distance = ((achievementsProgress[6] / 6f) * 1.4f) / 1000f;
        if (distance > 42.195) {
            distance = 42.195f;
        }
        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = Math.Round(distance, 3).ToString() + "km / 42.195km";

        float jumps;
        if (achievementsProgress[7] > 1000) {
            jumps = 1000f;
        }
        else {
            jumps = achievementsProgress[7];
        }
        m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(7).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        m_Text.text = jumps.ToString() + " / 1000";
    }

    public void CheckAchievementUnlocked () {
        for (int i = 0; i < achievementsUnlocked.Length; i++){
            if (achievementsUnlocked[i]) {
                m_MyColor = new Color(0.2762609f, 0.509804f, 0.2431373f, 1f);
                m_Graphic = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<Graphic>();
                m_Graphic.color = m_MyColor;
                if (i == 8) {
                    m_TMProText = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                    m_TMProText.text = "Stand Still for 15 Minutes";
                    m_Text = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
                    m_Text.text = "Completed!";
                }
            }
        }
    }
}
