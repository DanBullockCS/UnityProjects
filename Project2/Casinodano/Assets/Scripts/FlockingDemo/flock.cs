// Using this tutorial: https://www.youtube.com/watch?v=eMpI1eCsIyM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour {

    public float speed = 0.001f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;

    bool turning = false;

    void Start() {
        // Make fish swim at different speeds
        speed = Random.Range(0.7f, 2); 
    }

    void Update() {
        if (Vector3.Distance(transform.position, new Vector3(44.0f, 3.70f, -129.0f)) >= globalFlock.tankSize) {
            turning = true;
        } else {
            turning = false;
        }

        if (turning) {
            Vector3 direction = new Vector3(44.0f, 3.70f, -129.0f) - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.7f, 2); // Change speed again
        } else {
            if (Random.Range(0, 5) < 1) { ApplyRules(); }
        }

        transform.Translate(0, 0, Time.deltaTime * speed); // Make fish swim forward
    }

    // Swarming Behaviour Algorithm
    void ApplyRules() {
        GameObject[] gameObjs;
        gameObjs = globalFlock.fishyArr;

        Vector3 vCenter = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float gSpeed = 0.1f;
        float dist;
        Vector3 goalPos = globalFlock.goalPos;

        // Calculating groupSize based on what agents are within neighbourDistance
        int groupSize = 0;
        foreach (GameObject obj in gameObjs) {
            if(obj != this.gameObject) {
                dist = Vector3.Distance(obj.transform.position, this.transform.position);
                if (dist <= neighbourDistance) {
                    // Then other agent in a neighbour, add to group
                    vCenter += obj.transform.position;
                    groupSize++;

                    // If other agent is less than 1.0f away, avoid the collision
                    if (dist < 1.0f) {
                        vAvoid += this.transform.position - obj.transform.position;
                    }

                    flock anotherFlock = obj.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0) {
            // Create average speed for entire group (gSpeed is global speed)
            vCenter = vCenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position;
            // Agent is going to rotate
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }
}
