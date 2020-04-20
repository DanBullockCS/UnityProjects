// Setting the volume of the game via the Mixer and Audio Slider
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void setLevel (float sliderVal) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderVal)*20 - 10 ); // Turns value into -80 and 0 on a log scale
        // Used -10 because I started the sound of the mixer initially at -10db
    }

}
