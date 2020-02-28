// Check if the player hit some enemy or cacti and take away their hp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col) {
        // Player got hit for 10 hp
        if (col.gameObject.tag.Equals("Player")) {
            HP hp = col.gameObject.GetComponent<HP>();
            hp.Damage(10);
        }
    }
}