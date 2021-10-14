using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int coins;
    public float[] position;

    public PlayerData (Player Player) {
        level = Player.level;
        health = Player.health;
        coins = Player.coins;

        position = new float[3];
        for (int i = 0; i < 2; i++){
            position[0] = Player.transform.position.x;
            position[1] = Player.transform.position.y;
            position[2] = Player.transform.position.z;
        }

    }
}
