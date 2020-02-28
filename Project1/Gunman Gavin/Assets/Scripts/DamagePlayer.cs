// Check if the player hit some enemy or cacti and take away their hp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col) {
        // Player got hit for 10 hp
        if (col.gameObject.tag.Equals("Player")) {
            Animator objectAnimator = col.gameObject.GetComponent<Animator>();

            HP hp = col.gameObject.GetComponent<HP>();
            EnemyHP eHP = gameObject.GetComponent<EnemyHP>();

            if (objectAnimator.GetBool("punch") == false) {
                Debug.Log("Got Hit by" + col.gameObject.name);
                hp.Damage(10);
            } else {
                Debug.Log("punched enemy");
                eHP.TakeDamage(10);
            }
        }
    }
}