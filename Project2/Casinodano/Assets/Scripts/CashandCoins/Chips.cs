using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour {
    AudioSource ac;

    void Start() {
        ac = GetComponent<AudioSource>();
    }

    void OnMouseDown() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 5.0f) {
            // Play sound effect
            ac.PlayOneShot(ac.clip);
            // Do exchange based on white chip player clicked on
            if (CashCount.numCash > 0) {
                if (this.name == "CasinoChipsWhite") {
                    ChipCount.numChips += 1;
                    CashCount.numCash -= 1;
                } else if (this.name == "CasinoChipsRed") {
                    ChipCount.numChips += 5;
                    CashCount.numCash -= 5;
                } else if (this.name == "CasinoChipsBlue") {
                    ChipCount.numChips += 10;
                    CashCount.numCash -= 10;
                } else if (this.name == "CasinoChipsGreen") {
                    ChipCount.numChips += 25;
                    CashCount.numCash -= 25;
                } else if (this.name == "CasinoChipsBlack") {
                    ChipCount.numChips += 100;
                    CashCount.numCash -= 100;
                }
            } else {
                // Add an error sound effect here
            }
            
        }
    }
}
