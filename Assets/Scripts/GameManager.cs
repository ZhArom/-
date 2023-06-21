using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject endUI;
    public Text endMessage;
    public GameObject Setting;

    public static GameManager Instance;
    private EnemySpawner enemySpawner;
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "胜 利";
    }
    public void Failed()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "失 败";
    }

    public void OnButtonRetry()
    {
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(5);
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
    }
    public void NextOne()
    {
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        SceneManager.LoadScene(4);
    }

    public void Setting1Image()
    {
        Time.timeScale = 0;
        Setting.SetActive(true);
    }

    public void ClossSetting1Image()
    {
        Setting.SetActive(false);
        Time.timeScale = 1;
    }

    public void TCButton()
    {
        SceneManager.LoadScene(2);
    }

    public void CXButton()
    {
        SceneManager.LoadScene(3);
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        Time.timeScale = 1;
    }

    public void CXButton2()
    {
        Setting.SetActive(false);
        SceneManager.LoadScene(5);
        BuildManager.money = 1000;
        BuildManager.xieliang = 10;
        Time.timeScale = 1;
    }
}
