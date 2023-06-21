using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager2 : MonoBehaviour {
    public AudioSource au;
    public Slider slider;
    void Start()
    {
        au = au.GetComponent<AudioSource>();
        slider = slider.GetComponent<Slider>();
        
    }

    void Update()
    {
        au.volume = slider.value;
       
    }
}
