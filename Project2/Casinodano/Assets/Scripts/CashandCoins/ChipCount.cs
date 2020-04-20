// Counts chips and displays the counter in the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChipCount : MonoBehaviour {
    public static int numChips = 0;
    TMP_Text chipText;

    // Show counts
    void Start() {
        numChips = 0;
        chipText = GetComponent<TMP_Text>();
    }

    void Update() {
        chipText.text = numChips.ToString();
    }
}
