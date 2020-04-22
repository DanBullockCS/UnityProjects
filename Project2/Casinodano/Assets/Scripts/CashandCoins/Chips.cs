using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour {
    private AudioSource ac;
    private Animator anim;

    void Start() {
        ac = GetComponent<AudioSource>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    void OnMouseDown() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 5.0f) {
            // Do exchange based on chip player clicked on
            if (CashCount.numCash > 0) {
                if (this.name == "CasinoChipsWhite") {
                    // If there are still chips left on the table
                    if (transform.childCount > 0) {
                        anim.SetTrigger("PickObject");                                  // Play pickup animation
                        Destroy(this.GetComponent<Transform>().GetChild(0).gameObject); // Destroy that chip
                        ac.PlayOneShot(ac.clip);                                        // Play the sound
                        ChipCount.numChips += 1;                                        // Complete the transaction
                        CashCount.numCash -= 1;
                    }
                } else if (this.name == "CasinoChipsRed") {
                    if (transform.childCount > 0) {
                        anim.SetTrigger("PickObject");
                        Destroy(this.GetComponent<Transform>().GetChild(0).gameObject);
                        ac.PlayOneShot(ac.clip);
                        ChipCount.numChips += 5;
                        CashCount.numCash -= 5;
                    }
                } else if (this.name == "CasinoChipsBlue") {
                    if (transform.childCount > 0) {
                        anim.SetTrigger("PickObject");
                        Destroy(this.GetComponent<Transform>().GetChild(0).gameObject);
                        ac.PlayOneShot(ac.clip);
                        ChipCount.numChips += 10;
                        CashCount.numCash -= 10;
                    }
                } else if (this.name == "CasinoChipsGreen") {
                    if (transform.childCount > 0) {
                        anim.SetTrigger("PickObject");
                        Destroy(this.GetComponent<Transform>().GetChild(0).gameObject);
                        ac.PlayOneShot(ac.clip);
                        ChipCount.numChips += 25;
                        CashCount.numCash -= 25;
                    }
                } else if (this.name == "CasinoChipsBlack") {
                    if (transform.childCount > 0) {
                        anim.SetTrigger("PickObject");
                        Destroy(this.GetComponent<Transform>().GetChild(0).gameObject);
                        ac.PlayOneShot(ac.clip);
                        ChipCount.numChips += 100;
                        CashCount.numCash -= 100;
                    }
                }
            }
            
        }
    }
}
