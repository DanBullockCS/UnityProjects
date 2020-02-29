// Controls the collection and destruction of coins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public AudioClip coinSound;
    AudioSource aSource;
    GameObject obj;

    void Start() {
        obj = GameObject.Find("CoinSound");
        if (obj != null)
            aSource = obj.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Player")) {
            // Play coin sound
            aSource.clip = coinSound;
            aSource.Play();
            // Get the coin that was collected, add it and destroy it
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
