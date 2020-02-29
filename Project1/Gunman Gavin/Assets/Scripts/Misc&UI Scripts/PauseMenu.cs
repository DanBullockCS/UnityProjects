// Controling the Pause Menu during the RunGame scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject pauseCanvas;

    // Update is called once per frame
    void Update() {
        // Check if user hits esc to pause game.
        if (Input.GetKeyDown("escape")) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Pause() {
        //Time.timeScale = 0f; // This freezetime was causing errors with the menu buttons as they are controlled by the WASD/Arrow Keys
        pauseCanvas.SetActive(true);
        isPaused = true;
    }

    public void Resume() {
        //Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        isPaused = false;
    }

}
