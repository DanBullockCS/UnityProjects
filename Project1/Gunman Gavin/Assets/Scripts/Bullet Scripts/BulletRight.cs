// Create bullet and shoot it from tutorial: https://www.youtube.com/watch?v=wkKsl1Mfp5M

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRight : MonoBehaviour {
    public float speed = 20f;
    public new Rigidbody2D rigidbody;
    public int damage = 20;

    void Start() {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D objectHit) {
        if (objectHit.gameObject.tag.Equals("Enemy")) {
            EnemyHP eHP = objectHit.GetComponent<EnemyHP>();
            if (eHP != null) {
                eHP.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
