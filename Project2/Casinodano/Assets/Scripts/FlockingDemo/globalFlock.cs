using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {
    public GameObject fishPrefab;
    public GameObject fishPrefab2;
    public GameObject fishPrefab3;
    public GameObject fishPrefab4;

    public GameObject goalPrefab;
    public static Vector3 tankSize = new Vector3(1.0f, 0.5f, 2.0f);

    static int numFish = 20;
    public static GameObject[] fishyArr = new GameObject[numFish];

    // Hard coded to where the aquarium is
    public static Vector3 goalPos = new Vector3(44.0f, 3.70f, -129.0f);

    void Start() {
        // Create fish
        for(int i = 0; i < numFish; i++) {
            Vector3 pos = new Vector3(44.0f + Random.Range(-tankSize.x, tankSize.x), 3.70f + Random.Range(-tankSize.y, tankSize.y), -129.0f + Random.Range(-tankSize.z, tankSize.z));
            
            // Spawn a random fish out of the 4 available
            int randomFishNum = Random.Range(0, 4);
            switch(randomFishNum) {
                case 0:
                    fishyArr[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
                    break;
                case 1:
                    fishyArr[i] = (GameObject)Instantiate(fishPrefab2, pos, Quaternion.identity);
                    break;
                case 2:
                    fishyArr[i] = (GameObject)Instantiate(fishPrefab3, pos, Quaternion.identity);
                    break;
                case 3:
                    fishyArr[i] = (GameObject)Instantiate(fishPrefab4, pos, Quaternion.identity);
                    break;
            }
            
        }
    }

    void Update() {
        // Change the fishes goalPos to a random spot in the tank
        if (Random.Range (0, 20000) < 50) {
            goalPos = new Vector3(43.711f, 4.4f, + Random.Range(-130.283f, -127.273f));
        }
        goalPrefab.transform.position = goalPos;
    }
}
