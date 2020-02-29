// If the player has reached the goal, end the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedGoal : MonoBehaviour {
    private GameObject playerObj = null;
    private float goalPos = 112;

    void Start() {
        if (playerObj == null) {
            playerObj = GameObject.Find("Player");
        }
    }

    void Update() {
        // User has reached goal
        if (playerObj.transform.position.x >= goalPos) {
            StartCoroutine(GameOver());
            Time.timeScale = 1f;
            SceneManager.LoadScene("Winner");
        }
    }

    IEnumerator GameOver() {
        Time.timeScale = 0f;
        yield return new WaitForSeconds(5);
    }
}
