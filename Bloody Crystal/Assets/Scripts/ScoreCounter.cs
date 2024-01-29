using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreMeshText = null;
    [SerializeField] private GameObject _finalCanv = null;

    [SerializeField] private int setMaxScore = 200;
    [SerializeField] private int setMinScore = 0;

    void Update()
    {
        CounterSCore();
        SetTempScoreForSlots();
    }

    private void CounterSCore()
    {
        if (PlayerPrefs.GetInt("Total_Score") <= setMinScore || PlayerPrefs.GetInt("Total_Score") >= setMaxScore)
        {
            PlayerPrefs.SetInt("Check", 1);
        }
        if (PlayerPrefs.GetInt("Check") == 1)
        {
            _finalCanv.SetActive(true);
            _scoreMeshText.text = PlayerPrefs.GetInt("Total_Score").ToString();
        }
    }

    private void SetTempScoreForSlots()
    {
        if (PlayerPrefs.GetInt("Seven") == 2)
        {
            PlayerPrefs.SetInt("Seven_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Seven") == 3)
        {
            PlayerPrefs.SetInt("Seven_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Seven") == 4)
        {
            PlayerPrefs.SetInt("Seven_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Seven") == 5)
        {
            PlayerPrefs.SetInt("Seven_Temp", 50);
        }



        if (PlayerPrefs.GetInt("Cherry") == 2)
        {
            PlayerPrefs.SetInt("Cherry_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Cherry") == 3)
        {
            PlayerPrefs.SetInt("Cherry_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Cherry") == 4)
        {
            PlayerPrefs.SetInt("Cherry_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Cherry") == 5)
        {
            PlayerPrefs.SetInt("Cherry_Temp", 50);
        }


        if (PlayerPrefs.GetInt("Grace") == 2)
        {
            PlayerPrefs.SetInt("Grace_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Grace") == 3)
        {
            PlayerPrefs.SetInt("Grace_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Grace") == 4)
        {
            PlayerPrefs.SetInt("Grace_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Grace") == 5)
        {
            PlayerPrefs.SetInt("Grace_Temp", 50);
        }


        if (PlayerPrefs.GetInt("Lemon") == 2)
        {
            PlayerPrefs.SetInt("Lemon_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Lemon") == 3)
        {
            PlayerPrefs.SetInt("Lemon_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Lemon") == 4)
        {
            PlayerPrefs.SetInt("Lemon_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Lemon") == 5)
        {
            PlayerPrefs.SetInt("Lemon_Temp", 50);
        }


        if (PlayerPrefs.GetInt("Plum") == 2)
        {
            PlayerPrefs.SetInt("Plum_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Plum") == 3)
        {
            PlayerPrefs.SetInt("Plum_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Plum") == 4)
        {
            PlayerPrefs.SetInt("Plum_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Plum") == 5)
        {
            PlayerPrefs.SetInt("Plum_Temp", 50);
        }


        if (PlayerPrefs.GetInt("Watermelon") == 2)
        {
            PlayerPrefs.SetInt("Watermelon_Temp", 20);
        }
        else if (PlayerPrefs.GetInt("Watermelon") == 3)
        {
            PlayerPrefs.SetInt("Watermelon_Temp", 30);
        }
        else if (PlayerPrefs.GetInt("Watermelon") == 4)
        {
            PlayerPrefs.SetInt("Watermelon_Temp", 40);
        }
        else if (PlayerPrefs.GetInt("Watermelon") == 5)
        {
            PlayerPrefs.SetInt("Watermelon_Temp", 50);
        }
    }
}
