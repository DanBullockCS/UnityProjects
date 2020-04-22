using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cash : MonoBehaviour {
    private AudioSource ac;
    private Animator anim;

    void Start() {
        ac = GetComponent<AudioSource>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    void OnMouseDown() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 1.5f && ChipCount.numChips > 0) {
            anim.SetTrigger("PickObject");
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
