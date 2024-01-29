using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour // Прикреплён к Assets/Prefabs/SceneChanger.prefab
// Обычный менятель сцен и выход из игры, привязанный ко всем кнопкам
{
    public void ChangeSceneGame(string sceneName)
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChangeSceneMenu(string sceneName)
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
