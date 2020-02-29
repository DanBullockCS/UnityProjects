// If the player has reached the goal, end the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedGoal : MonoBehaviour {
    private GameObject playerObj = null;
    public GameObject EnemyCowboy;
    private float goalPos = 112f;
    private float bossPos = 88.47997f;

    void Start() {
        if (playerObj == null) {
            playerObj = GameObject.Find("Player");
        }
    }

    void Update() {
        if (EnemyCowboy != null) {
            // User is near boss spawn boss
            if (playerObj.transform.position.x >= bossPos) {
                EnemyCowboy.SetActive(true);
            }
        }

        // User has reached goal
        if (playerObj.transform.position.x >= goalPos) {
            SceneManager.LoadScene("Winner");
        }
    }
}
