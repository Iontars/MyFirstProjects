using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvMenu = null;
    [SerializeField] private GameObject _canvFinalMenu = null;
    [SerializeField] private TextMeshProUGUI _scoreMeshText = null;

    public void SceneManagerButtons(string input)
    {
        if (input == "Game")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Total_Score", 100);
            _scoreMeshText.text = PlayerPrefs.GetInt("Total_Score").ToString();
            _canvMenu.SetActive(false);
            _canvFinalMenu.SetActive(false);

        }
        else if (input == "StartMenu")
        {
            _canvMenu.SetActive(true);
            _canvFinalMenu.SetActive(false);
            PlayerPrefs.SetInt("Check", 0);

        }
        else if (input == "Exit")
        {
            Application.Quit();
        }

    }
}
