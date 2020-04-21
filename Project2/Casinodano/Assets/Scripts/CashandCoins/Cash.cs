using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cash : MonoBehaviour {
    AudioSource ac;

    void Start() {
        ac = GetComponent<AudioSource>();
    }

    void OnMouseDown() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 1.5f && ChipCount.numChips > 0) {
            // Play the sound and give exchange all the chips for cash
            ac.PlayOneShot(ac.clip);
            CashCount.numCash += ChipCount.numChips;
            ChipCount.numChips = 0;
        }

        if (CashCount.numCash >= 3000) {
            // You Beat the game since you got more than $3000
            Cursor.lockState = CursorLockMode.None; // Show the cursor and unlock it
            SceneManager.LoadScene("EndGame");
        }
    }
}
