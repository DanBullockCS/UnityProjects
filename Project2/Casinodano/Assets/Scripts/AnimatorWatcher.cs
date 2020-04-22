// A script to just watch the animator, I use it to speed up the pickobject animation by 3x
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorWatcher : MonoBehaviour {
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Pick Object")){
            anim.speed = 3;
        } else {
            anim.speed = 1;
        }
    }
}
