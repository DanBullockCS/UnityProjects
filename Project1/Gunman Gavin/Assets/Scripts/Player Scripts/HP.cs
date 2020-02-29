// Controls the HP of the player, Original script from: https://github.com/csci4160u/examples/blob/master/04b_User_Interfaces/Assets/HP.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour {
    public int hitPoints = 0; // 0 is actually full hp and 50 is dead, (just the way I implemented the slider...)
    public Slider healthBar = null;

    AudioSource aSource;
    GameObject obj;

    void Start() {
        obj = GameObject.Find("PlayerPainSoundEffect");
        if (obj != null)
            aSource = obj.GetComponent<AudioSource>();
    }

    public void Damage(int amount) {
        // Player took damage, play hurt sound effect
        if (amount > 0) {
            aSource.Play();
        }

        hitPoints += amount;
        // Stop HP from going more than bar lets.
        if (hitPoints <= 0) {
            hitPoints = 0;
        }
        if (hitPoints >= 50) {
            SceneManager.LoadScene("DeathScreen");
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar() {
        if (healthBar != null) {
            healthBar.value = this.hitPoints;
        }
    }
}