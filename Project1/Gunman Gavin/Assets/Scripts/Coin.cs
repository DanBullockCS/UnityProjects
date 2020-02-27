// Controls the collection and destruction of coins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag.Equals("Player")) {
            // Add to some sort of counter later
            //SoundManagerScript.PlaySound("coinPickup");
            Destroy(gameObject);
        }
    }
}
