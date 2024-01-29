using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour

{
    [SerializeField] private Spiner _spiner = null;
    [SerializeField] private GameObject _restartButton = null;
    [SerializeField] private GameObject _finalBoard = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _spinCountText1 = null;
    [SerializeField] private TextMeshProUGUI _spinCountText2 = null;
    [Space]
    [SerializeField] private int strartScore = 125000;
    [SerializeField] private int strartSpinAmount = 7;
    public int StrartScore {get => strartScore;}
    public int StrartSpinAmount { get => strartSpinAmount; }


    void Update()
    {
        SetInfoOnBoard();
        AddInfoOnBoard();
    }

    private void SetInfoOnBoard()
    {
        _spinCountText1.text = PlayerPrefs.GetInt("Start_Spins").ToString();
        _spinCountText2.text = PlayerPrefs.GetInt("TotalScore").ToString();
    }

    private void AddInfoOnBoard()
    {
        if (_spiner.Speed == 0)
        {
            if (PlayerPrefs.GetInt("Start_Spins") >= 0)
            {
                PlayerPrefs.SetInt("Start_Spins", PlayerPrefs.GetInt("Spin_Count") + PlayerPrefs.GetInt("Start_Spins"));
                PlayerPrefs.DeleteKey("Spin_Count");
            }

            if (PlayerPrefs.GetInt("TotalScore") >= 1000000 || PlayerPrefs.GetInt("Start_Spins") <= 0)
            {
                _restartButton.SetActive(true);
                _finalBoard.SetActive(true);
            }
            PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("Spin_Score") + PlayerPrefs.GetInt("TotalScore"));
            PlayerPrefs.DeleteKey("Spin_Score");
        }

    }
}
