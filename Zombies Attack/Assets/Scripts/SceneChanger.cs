using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour // ��������� � Assets/Prefabs/SceneChanger.prefab
// ������� �������� ���� � ����� �� ����, ����������� �� ���� �������
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
