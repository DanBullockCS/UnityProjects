﻿// Showing the enemies death from tutorial: https://www.youtube.com/watch?v=wkKsl1Mfp5M
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    [SerializeField] public int health = 100;
    Animator _animator;

    void Start() {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage (int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }
    
    void Die() {
        // Play death animation
        _animator.SetTrigger("isShot");
    }
}