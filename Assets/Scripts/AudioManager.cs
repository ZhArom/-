using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public AudioSource au;
    public Slider slider;
    public Toggle toggle;
    void Start()
    {
        au = au.GetComponent<AudioSource>();
        slider = slider.GetComponent<Slider>();
        toggle = toggle.GetComponent<Toggle>();
    }

    void Update()
    {
        au.volume = slider.value;
        au.mute = toggle.isOn;
    }

    private void OnExitGame2()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
