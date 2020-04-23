// Shows a phone message when you click on the phone at the start of the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour {
    [SerializeField] public GameObject message;
    private Animator anim;
    private bool playedMessage = false; // They can only play the phone message one time

    void Start() {
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    void OnMouseDown() {
        if (this.name == "Phone" && !playedMessage) {
            playedMessage = true;
            anim.SetTrigger("PickObject");
            showPhoneMessage();
            Invoke("hidePhoneMessage", 5);
        }
    }

    void showPhoneMessage() {
        message.SetActive(true);
    }

    void hidePhoneMessage() {
        message.SetActive(false);
    }
}
