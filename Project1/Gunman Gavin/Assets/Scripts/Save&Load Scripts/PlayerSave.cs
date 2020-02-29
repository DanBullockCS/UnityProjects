// Saving scripts from tutorial: https://www.youtube.com/watch?v=XOjd_qU2Ido
// Honestly Save states make the game way too easy, but oh well

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSave {

    public int numCoins;
    public float[] position;

    public PlayerSave(Player player) {
        numCoins = CoinCount.numCoins;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}