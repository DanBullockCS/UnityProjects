using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour {
    [SerializeField] public GameObject message;
    
    void OnMouseDown() {
        if (this.name == "Phone") {
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
