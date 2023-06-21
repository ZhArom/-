using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public GameObject settingPanel;
    public GameObject leve;

    // Use this for initialization
    void Start()
    {
    }
    public void PlayerGame()
    {
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void PlayerGame2()
    {
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void FanHui()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void Leve()
    {
        leve.SetActive(true);
    }

    public void Return()
    {
        leve.SetActive(false);
    }

    private void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {

    }
}
