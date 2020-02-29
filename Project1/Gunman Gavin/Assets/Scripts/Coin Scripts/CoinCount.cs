// Counts coins and displays the counter in the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCount : MonoBehaviour {
    public static int numCoins = 0;
    TMP_Text text;

    // Show coin count
    void Start() {
        numCoins = 0;
        text = GetComponent<TMP_Text>();
    }
    void Update() {
        text.text = numCoins.ToString();
    }
}
