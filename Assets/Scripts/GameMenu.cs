using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void OnStartGame()
    {
        BuildManager.money = 1000;
        SceneManager.LoadScene(3);
    }
    public void OnExitGame()
    {
        SceneManager.LoadScene(2);
    }
}
