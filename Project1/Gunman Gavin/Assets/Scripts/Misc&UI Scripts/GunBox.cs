// Controls the collection and destruction of coins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : MonoBehaviour {
    public bool hasGun = false;
    [SerializeField] Animator animator = null;
    [SerializeField] GameObject WeaponSlot = null; // Gun slot
    [SerializeField] GameObject HandSlot = null; // Hand slot

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Player")) {
            // Switch to gun
            hasGun = true;
        }

        if (hasGun) {
            // User now has the gun
            animator.SetBool("hasGun", true);
            WeaponSlot.SetActive(true);
            HandSlot.SetActive(false);
        }
    }
}
