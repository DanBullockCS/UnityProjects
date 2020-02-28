// Create bullet and shoot it from tutorial: https://www.youtube.com/watch?v=wkKsl1Mfp5M

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeft : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rigidbody;
    public int damage = 20;

    void Start() {
        rigidbody.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D objectHit) {
        // Bullet hit an enemy
        if (objectHit.gameObject.tag.Equals("Enemy")) {
            EnemyHP eHP = objectHit.GetComponent<EnemyHP>();
            if (eHP != null) {
                eHP.TakeDamage(damage);
            }
        // Bullet hit the player
        } else if (objectHit.gameObject.tag.Equals("Player")) {
            HP hp = objectHit.GetComponent<HP>();
            if (hp != null) {
                hp.Damage(10);
            }
        }
        Destroy(gameObject);
    }
}
