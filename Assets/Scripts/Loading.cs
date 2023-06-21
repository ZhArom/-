using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {
    public Slider slider;
    public Text text;
    float t = 0;
    // Use this for initialization
    void Start()
    {
        slider = slider.GetComponent<Slider>();
        text = text.GetComponent<Text>();
        slider.maxValue = 100;
        slider.value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 5)
        {
            t = 5;
            Invoke("JumpGameScene", 1);
        }
        slider.value = t * 20;
        text.text = (int)slider.value + "%";
    }
    void JumpGameScene()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
