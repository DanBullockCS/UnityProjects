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

            // Never really got this punching to work properly.
            if (objectAnimator.GetBool("punch") == false) {
                hp.Damage(10);
            } else {
                Debug.Log("punched enemy");
                eHP.TakeDamage(10);
            }
        }
    }
}