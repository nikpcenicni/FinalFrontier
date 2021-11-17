using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AchievementMenu : MonoBehaviour
{
    public Graphic m_Graphic;
    public Color m_MyColor;
    public bool[] achievementsUnlocked = new bool[7];
    public float[] achievementsProgress = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        loadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        loadPlayer();
        setAchievementProgress();
        CheckAchievementUnlocked();
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
        for (int i = 0; i < achievementsProgress.Length; i++)
        {
            
        }
    }

    public void CheckAchievementUnlocked () {
        for (int i = 0; i < achievementsUnlocked.Length; i++){
            if (achievementsUnlocked[i]) {
                m_MyColor = new Color(0.2762609f, 0.509804f, 0.2431373f, 1f);
                m_Graphic = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.GetComponent<Graphic>();
                m_Graphic.color = m_MyColor;
            }
        }
    }
}
