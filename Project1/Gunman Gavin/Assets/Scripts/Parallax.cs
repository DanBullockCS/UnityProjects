// The background Parallax effect controlled here
// Parallax Effect from Tutorial: https://www.youtube.com/watch?v=zit45k6CUMk
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour { 
     
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Set the starting x pos and the length of the sprite
    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update() {
        float tempMove = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // Repeat Background
        if (tempMove > startpos + length) startpos += length;
        else if (tempMove < startpos - length) startpos -= length;
    }
}
