// Controls the enemy movement behaviour (not really input, but I wanted it to be in line with the PlayerInput script)
// Originally from this thread: https://forum.unity.com/threads/moving-an-object-back-and-forth-on-a-single-axis-automatically.235033/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour {
    public Vector3 pointB;
    public Vector3 pointA;

    IEnumerator Start() {
        pointA = transform.position;
        while (true) {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 2.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 2.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f) {
            // Flippin the enemy
            if (thisTransform.position.x <= pointB.x) {
                thisTransform.localScale = new Vector3(-2, 2, 2);
            } else if (thisTransform.position.x == pointA.x) {
                thisTransform.localScale = new Vector3(2, 2, 2);
            }

            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

}
