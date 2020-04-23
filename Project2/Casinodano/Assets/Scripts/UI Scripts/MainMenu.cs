// Controling the Main Menu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Load other scenes
    public void GoToPlayGame () {
        SceneManager.LoadScene("MainGame");
    }
    public void GoToSettings() {
        SceneManager.LoadScene("Settings");
    }
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
