using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;
    [SerializeField] GameObject selector; // The highlighted rectangle for each object

    void Update() {
        // User selected this button
        if (menuButtonController.index == thisIndex) {
            animator.SetBool("selected", true);
            selector.SetActive(true);
            // Check if the user pressed the button
            if (Input.GetAxis("Submit") == 1) {
                animator.SetBool("pressed", true);
                // Change the scene (or exit game if index is 2)
                if (thisIndex == 0) {
                    GotoGame();
                } else if (thisIndex == 1) {
                    GotoSettings();
                } else if (thisIndex == 2) {
                    QuitGame();
                }
            } else if (animator.GetBool("pressed")) {
                animator.SetBool("pressed", false);
            }
        } else {
            animator.SetBool("selected", false);
            selector.SetActive(false);
        }
    }

    // Changing Scene functions
    public void GotoSettings() {
        SceneManager.LoadScene("Settings");
    }
    public void GotoGame() {
        SceneManager.LoadScene("RunGame");
    }
    public void QuitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
