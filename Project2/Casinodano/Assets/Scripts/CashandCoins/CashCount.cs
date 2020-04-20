// Counts cash and displays the counter in the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashCount : MonoBehaviour {
    public static int numCash = 10000;
    TMP_Text cashText;

    // Show counts
    void Start() {
        numCash = 10000;
        cashText = GetComponent<TMP_Text>();
    }

    void Update() {
        cashText.text = numCash.ToString();
    }
}
