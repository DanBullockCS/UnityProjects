// Counts cash and displays the counter in the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashCount : MonoBehaviour {
    public static int numCash = 2820; // You start with exactly enough money to buy all the chips at the front desk
    TMP_Text cashText;

    // Show counts
    void Start() {
        numCash = 2820;
        cashText = GetComponent<TMP_Text>();
    }

    void Update() {
        cashText.text = numCash.ToString();
    }
}
