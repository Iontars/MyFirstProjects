using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenes : MonoBehaviour
{

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void SceneChange(string input)
    {
        switch(input)
        {
            case "0": SceneManager.LoadScene(0); Ball.points = 0; break;
            case "1": SceneManager.LoadScene(1); break;
            case "2": SceneManager.LoadScene(2); break;
            case "Exit": Application.Quit(); break;
        }
    }
}
