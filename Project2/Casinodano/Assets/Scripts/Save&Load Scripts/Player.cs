// Saving scripts from tutorial: https://www.youtube.com/watch?v=XOjd_qU2Ido

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int numChips = 0;
    public int numCash = 0;

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerSave data = SaveSystem.LoadPlayer();

        ChipCount.numChips = data.numChips;
        CashCount.numCash = data.numCash;

        // Doesn't seem to want to translate the player, but left the code in for completeness
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
