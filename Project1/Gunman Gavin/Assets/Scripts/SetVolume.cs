using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void setLevel (float sliderVal) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderVal)*20 ); // Turns value into -80 and 0 on a log scale
    }

}
