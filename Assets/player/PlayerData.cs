using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int bank;
    public bool[] achievementsUnlocked = new bool[9];
    public float[] achievementsProgress = new float[9];
    public bool[] weapons = new bool[3];

    public PlayerData (Player Player) {
        level = Player.level;
        health = Player.currentHealth;
        bank = Player.bank;
        for (int i = 0; i < weapons.Length; i ++){
            weapons[i] = Player.weapons[i];
        }

        for (int i = 0; i < achievementsUnlocked.Length; i++) {
            achievementsUnlocked[i] = Player.achievementsUnlocked[i];
        }
        for (int i = 0; i < achievementsProgress.Length; i++)
        {
            achievementsProgress[i] = Player.achievementsProgress[i];
        }
    }
}
