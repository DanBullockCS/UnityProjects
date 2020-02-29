// Saving scripts from tutorial: https://www.youtube.com/watch?v=XOjd_qU2Ido

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int numCoins = 0;

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerSave data = SaveSystem.LoadPlayer();

        CoinCount.numCoins = data.numCoins;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
