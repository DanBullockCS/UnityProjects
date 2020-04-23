// Plays audio when you press on an object that has this script
using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {
    AudioSource ac;
    public bool isPlayed = false;

    void Start() {
        ac = GetComponent<AudioSource>();
    }
    // Play sound when you click on object
    void OnMouseDown() {
        if (!isPlayed) {
            // Only play sound if you are really close to object
            if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 2.5f) {
                ac.PlayOneShot(ac.clip);
                isPlayed = true;
            }
        }

    }
}