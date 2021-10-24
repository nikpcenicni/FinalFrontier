using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int bank;
    public int[,,] items = new int[10,10,2];

    public PlayerData (Player Player) {
        level = Player.level;
        health = Player.health;
        bank = Player.bank;
    }
}
