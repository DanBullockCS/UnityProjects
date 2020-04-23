// Controling the Pause Menu during the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject pauseCanvas;
    public GameObject MainCamera;

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
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        MainCamera.GetComponent<MouseInput>().enabled = false;
        isPaused = true;
    }

    public void Resume() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        MainCamera.GetComponent<MouseInput>().enabled = true;
        isPaused = false;
    }

    // Load other scenes
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

}
