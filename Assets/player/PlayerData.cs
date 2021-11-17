using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int bank;
    public bool[] achievementsUnlocked = new bool[7];
    public float[] achievementsProgress = new float[7];
    public int[,,] items = new int[10,10,2];

    public PlayerData (Player Player) {
        level = Player.level;
        health = Player.health;
        bank = Player.bank;
        for (int i = 0; i < achievementsUnlocked.Length; i++) {
            achievementsUnlocked[i] = Player.achievementsUnlocked[i];
        }
        for (int i = 0; i < achievementsProgress.Length; i++)
        {
            achievementsProgress[i] = Player.achievementsProgress[i];
        }
    }
}
