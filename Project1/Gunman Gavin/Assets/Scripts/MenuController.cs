using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    [SerializeField] GameObject selector; // The highlighted rectangle for each object

    string sceneName;

    void Start() {
        // Get the current scene so that I can make buttons do different things on different scenes
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update() {
        // User selected this button
        if (menuButtonController.index == thisIndex) {
            animator.SetBool("selected", true);
            selector.SetActive(true); // Show the rectangle
            // Check if the user pressed the button
            if (Input.GetAxis("Submit") == 1) {
                animator.SetBool("pressed", true);
                // Change the scene from Main menu
                if (thisIndex == 0 && sceneName == "MainMenu") {
                    GotoGame();
                } else if (thisIndex == 1 && sceneName == "MainMenu") {
                    GotoSettings();
                } else if (thisIndex == 2 && sceneName == "MainMenu") {
                    QuitGame();
                // Change the scene from DeathScreen
                } else if (thisIndex == 0 && sceneName == "DeathScreen") {
                    GotoGame();
                } else if (thisIndex == 1 && sceneName == "DeathScreen") {
                    GotoMainMenu();
                // Change the scene from Settings
                } else if (thisIndex == 1 && sceneName == "Settings") {
                    GotoMainMenu();
                }
            } else if (animator.GetBool("pressed")) {
                animator.SetBool("pressed", false);
            }
        } else {
            animator.SetBool("selected", false);
            selector.SetActive(false); // Hide the rectangle
        }
    }

    // Changing Scene functions
    public void GotoSettings() {
        SceneManager.LoadScene("Settings");
    }
    public void GotoGame() {
        SceneManager.LoadScene("RunGame");
    }
    public void GotoMainMenu() {
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
