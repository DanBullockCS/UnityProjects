// Set on each machine so player can play on any one
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMachine : MonoBehaviour {
    public GameObject machineCanvas;
    public GameObject pauseCanvas;
    public GameObject player;
    public GameObject machineCam;

    void Update() {
        // You can also leave the machine with the escape key
        if (Input.GetKeyDown("space")) {
            leaveMachine();
        }
    }

    void OnMouseDown() {
        // Open Slot Machine "Game"
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 2.5f) {
            Cursor.lockState = CursorLockMode.None;
            machineCanvas.SetActive(true);
            player.SetActive(false);
            machineCam.SetActive(true);
            pauseCanvas.SetActive(false);
        }
    }

    // Close the machine
    public void leaveMachine() {
        Cursor.lockState = CursorLockMode.Locked;
        machineCanvas.SetActive(false);
        player.SetActive(true);
        machineCam.SetActive(false);
        pauseCanvas.SetActive(true);
    }
}
