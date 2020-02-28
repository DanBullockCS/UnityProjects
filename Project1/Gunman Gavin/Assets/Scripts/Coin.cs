// Controls the collection and destruction of coins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Player")) {
            // Add to some sort of counter later
            //SoundManagerScript.PlaySound("coinPickup");
            GetCoin(col);
            Destroy(gameObject);
        }
    }

    public void GetCoin(Collider2D col) {
        CoinCount.numCoins += 1;
        // Every 5 coins the user gets 10 hp back
        if (CoinCount.numCoins % 5 == 0) {
            HP hp = col.gameObject.GetComponent<HP>();
            hp.Damage(-10);
        }

    }
}
