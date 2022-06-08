using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class soundController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource audioSource;
    static public float volume;

     void Awake()
    {
        volumeSlider.value = sceneVarPassover.volume;
    }

    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value;
        volume = volumeSlider.value;
    }
}
