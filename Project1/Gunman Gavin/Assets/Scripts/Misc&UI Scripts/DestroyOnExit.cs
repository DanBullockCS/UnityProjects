// Destroys the object when you when its done its death animation
// From unity forum: https://answers.unity.com/questions/670860/delete-object-after-animation-2d.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : StateMachineBehaviour {
    AudioSource aSource;
    GameObject Obj;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (animator.gameObject.name == "Bat" || animator.gameObject.name == "Rat") {
            Obj = GameObject.Find("RatBatDeathSoundEffect");
            if (Obj != null)
                aSource = Obj.GetComponent<AudioSource>();
        } else if (animator.gameObject.name == "Snake"){
            Obj = GameObject.Find("SnakeDeathSoundEffect");
            if (Obj != null)
                aSource = Obj.GetComponent<AudioSource>();
        } else if (animator.gameObject.name == "EnemyCowboy") {
            Obj = GameObject.Find("CowboyDeathSoundEffect");
            if (Obj != null)
                aSource = Obj.GetComponent<AudioSource>();
        }
        
        aSource.Play();
        
        Destroy(animator.gameObject, stateInfo.length);
        if (animator.gameObject.name == "EnemyCowboy") {
            GameObject.Find("Backdoor").SetActive(false);
        }
    }
}
