using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public void SetLevel(float slidervalue)
    {
        _mixer.SetFloat("MusicVol", Mathf.Log10 (slidervalue) * 20);
    }
}
