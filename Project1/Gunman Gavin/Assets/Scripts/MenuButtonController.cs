using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A general class to make the buttons in my menus cycle through the indices of the buttons

public class MenuButtonController : MonoBehaviour {
    public int index;
    [SerializeField] int maxIndex;
    [SerializeField] bool isKeyDown;

    // Checks which button we are currently highlighting so that user can click on them
    void Update() {
        if (Input.GetAxis("Vertical") != 0) {
            if (!isKeyDown) {
                if (Input.GetAxis("Vertical") < 0) {
                    if(index < maxIndex) {
                        index++;
                    } else {
                        index = 0; // Stay at first button
                    }
                } else if(Input.GetAxis("Vertical") > 0) {
                    if (index > 0) {
                        index--;
                    } else {
                        index = maxIndex; // Stay at last button
                    }
                }
                isKeyDown = true;
            }
        } else {
            isKeyDown = false;
        }
    }
}
