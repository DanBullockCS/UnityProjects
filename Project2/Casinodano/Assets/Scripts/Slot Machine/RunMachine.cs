using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunMachine : MonoBehaviour {
    // Three slot machine slot objects
    [SerializeField] private Image Slot1;
    [SerializeField] private Image Slot2;
    [SerializeField] private Image Slot3;

    // Slot machine pictures
    [SerializeField] private Sprite seven;
    [SerializeField] private Sprite apple;
    [SerializeField] private Sprite grapes;

    void Start() {

    }

    void Update() {

    }

    public void pullLever() {
        // Get random numbers
        int slot1 = Random.Range(1, 4);
        int slot2 = Random.Range(1, 4);
        int slot3 = Random.Range(1, 4);
        
        // Show the pictures
        switch(slot1) {
            case 1:
                Slot1.sprite = apple;
                break;
            case 2:
                Slot1.sprite = grapes;
                break;
            case 3:
                Slot1.sprite = seven;
                break;
        }
        switch (slot2) {
            case 1:
                Slot2.sprite = apple;
                break;
            case 2:
                Slot2.sprite = grapes;
                break;
            case 3:
                Slot2.sprite = seven;
                break;
        }
        switch (slot3) {
            case 1:
                Slot3.sprite = apple;
                break;
            case 2:
                Slot3.sprite = grapes;
                break;
            case 3:
                Slot3.sprite = seven;
                break;
        }

    }
}
