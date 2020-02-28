// Controls the cowboy at the end of the level (He goes up and down, instead of left and right)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInput : MonoBehaviour {
    public Vector3 pointB;
    public Vector3 pointA;
    public Transform firePt;
    public GameObject bulletPrefab;

    IEnumerator Start() {
        StartCoroutine(waitForNextBullet());
        while (true) {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 0.5f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
    
    // Enemy Shoot every 0.75 seconds
    IEnumerator waitForNextBullet() {
        while (true) {
            yield return new WaitForSeconds(0.75f);
            Shoot();
        }
    }

    void Shoot() {
        // Shooting logic
        Instantiate(bulletPrefab, firePt.position, firePt.rotation);
    }
}
