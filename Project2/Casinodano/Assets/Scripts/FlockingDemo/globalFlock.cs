using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {
    public GameObject fishPrefab;
    public GameObject fishPrefab2;
    public GameObject fishPrefab3;
    public GameObject fishPrefab4;
    public GameObject fishPrefab5;

    public GameObject goalPrefab;
    public static float tankSize = 2f;

    static int numFish = 20;
    public static GameObject[] fishyArr = new GameObject[numFish];

    // Hard coded to where the aquarium is
    public static Vector3 goalPos = new Vector3(44.0f, 3.70f, -129.0f);

    void Start() {
        // Create fish
        for(int i = 0; i < numFish; i++) {
            Vector3 pos = new Vector3(44.0f + Random.Range(-tankSize, tankSize), 3.70f + Random.Range(-tankSize, tankSize), -129.0f + Random.Range(-tankSize, tankSize));
            
            fishyArr[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
    }

    void Update() {
        // Change the fishes goalPos to wherever the fish food object is
        goalPos = goalPrefab.transform.position;
    }
}
