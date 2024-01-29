using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvas = null;
    [SerializeField] private GameObject _gameCanvas = null;
    [Space]
    [SerializeField] private GameObject _finalBoard = null;
    [SerializeField] private GameObject _buttonRestart = null;
    [Space]
    [SerializeField] private ScoreCounter _getStartValues = null;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void SetStartValues()
    {
        PlayerPrefs.SetInt("Start_Spins", _getStartValues.StrartSpinAmount);
        PlayerPrefs.SetInt("TotalScore", _getStartValues.StrartScore);
        PlayerPrefs.SetInt("Spin_Score", 0);
        PlayerPrefs.SetInt("Spin_Count", 0);
    }

    public void SceneChangerButtons(string canv)
    {
        if (canv == "Game")
        {
            _mainMenuCanvas.SetActive(false);
            _gameCanvas.SetActive(true);
            _finalBoard.SetActive(false);
            _buttonRestart.SetActive(false);
            SetStartValues();
        }
        else
        {
            _mainMenuCanvas.SetActive(true);
            _gameCanvas.SetActive(false);
            _finalBoard.SetActive(false);
            SetStartValues();
        }
    }

}
