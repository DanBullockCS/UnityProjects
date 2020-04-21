// Saving scripts from tutorial: https://www.youtube.com/watch?v=XOjd_qU2Ido

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSave {

    public int numChips;
    public int numCash;
    public float[] position;

    public PlayerSave(Player player) {
        numChips = ChipCount.numChips;
        numCash = CashCount.numCash;
       
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}