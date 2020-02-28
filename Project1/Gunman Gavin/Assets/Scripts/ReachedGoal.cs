// If the player has reached the goal, end the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedGoal : MonoBehaviour {
    private GameObject playerObj = null;
    private float goalPos = 102;

    void Start() {
        if (playerObj == null) {
            playerObj = GameObject.Find("Player");
        }
    }

    void Update() {
        // User has reached goal
        if (playerObj.transform.position.x >= goalPos) {
            Debug.Log("Reached Goal");
            // TODO Change this to victory screen
            SceneManager.LoadScene("MainMenu");
        }
    }
}
