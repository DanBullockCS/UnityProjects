// Destroys the object when you when its done its death animation
// From unity forum: https://answers.unity.com/questions/670860/delete-object-after-animation-2d.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : StateMachineBehaviour {
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.gameObject, stateInfo.length);
    }
}
