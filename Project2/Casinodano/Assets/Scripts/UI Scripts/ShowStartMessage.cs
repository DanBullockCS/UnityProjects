// Shows a how to play message at the start of the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStartMessage : MonoBehaviour {
    [SerializeField] public GameObject message;

    // Hide the message after 10 seconds
    void Awake() {
        Invoke("hidePhoneMessage", 10);
    }

    void hidePhoneMessage() {
        message.SetActive(false);
    }
}
