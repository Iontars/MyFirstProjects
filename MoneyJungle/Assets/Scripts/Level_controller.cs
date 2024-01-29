using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_controller : MonoBehaviour
{
    [SerializeField] private GameObject _stickLvl_1 = null;
    [SerializeField] private GameObject _stickLvl_2 = null;
    [SerializeField] private GameObject _stickLvl_3 = null;
    [SerializeField] private GameObject _stickLvl_4 = null;
    [SerializeField] private GameObject _stickLvl_5 = null;
    [SerializeField] private GameObject _stickLvl_6 = null;
    [SerializeField] private GameObject _canvGoodGame = null;

    [SerializeField] private Text _timerValue = null;
    [SerializeField] private Text _currentScore = null;
    [SerializeField] private Text _timeGoodGame = null;

    [SerializeField] private Level_menu_s _sendValue;
                                                    
    [SerializeField] private GameObject[] _obstacles = null;

    [SerializeField] private GameObject[] _buttonsGoodGame = null;

    private int _scoreForWin;
    private int _currentTime;
    private int _currentLvl;

    private float _startTime;
    private float _timeForStars_3;
    private float _timeForStars_2;

    public int  CurrentTime
    {
        get
        {
            return _currentTime;
        }
    }
    public void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("TotalCost");
        ConfigSet();
        InstObjects();
    }
    #region auto set what lvl we play
    public void ConfigSet()
    {
        switch(PlayerPrefs.GetInt("PreferensesSet"))
        {
            case 1: ConfigLvl(PlayerPrefs.GetInt("Level_1_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_1_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_1_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_1.SetActive(true);
                break;
            case 2:
                ConfigLvl(PlayerPrefs.GetInt("Level_2_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_2_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_2_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_2.SetActive(true);
                break;
            case 3:
                ConfigLvl(PlayerPrefs.GetInt("Level_3_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_3_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_3_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_3.SetActive(true);
                break;
            case 4:
                ConfigLvl(PlayerPrefs.GetInt("Level_4_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_4_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_4_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_4.SetActive(true);
                break;
            case 5:
                ConfigLvl(PlayerPrefs.GetInt("Level_5_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_5_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_5_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_5.SetActive(true);
                break;
            case 6:
                ConfigLvl(PlayerPrefs.GetInt("Level_6_ScoreInfo"), PlayerPrefs.GetFloat("Lvl_6_TimeFor_3_Stars"), PlayerPrefs.GetFloat("Lvl_6_TimeFor_2_Stars"));
                _currentLvl = PlayerPrefs.GetInt("PreferensesSet");
                _stickLvl_6.SetActive(true);
                break;
        }
    }
    #endregion

    #region set obstacles for lvl
    private void InstObjects()
    {
        switch(PlayerPrefs.GetInt("PreferensesSet"))
        {
            case 1:
                Instantiate(_obstacles[1], new Vector2(-3, -1), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-2, -3), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, 1), Quaternion.identity);
                break;
            case 2:
                Instantiate(_obstacles[1], new Vector2(-4, 2), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(3, 2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(1, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(-1, -5), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(2, -2), Quaternion.identity);
                break;
            case 3:
                Instantiate(_obstacles[1], new Vector2(-2, -1), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(2, 4), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(-4, -4), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, 1), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, -4), Quaternion.identity);
                break;
            case 4:
                Instantiate(_obstacles[1], new Vector2(-3, 3), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(3, 3), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-2, -3), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, 3), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(2, 1), Quaternion.identity);
                break;
            case 5:
                Instantiate(_obstacles[1], new Vector2(-4, -4), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(3, -4), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-4, 3), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(3, -3), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(0, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(0, 2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(0, 1), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-4, 0), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(2, -1), Quaternion.identity);
                break;
            case 6:
                Instantiate(_obstacles[1], new Vector2(-2, -0), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(3, 0), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-2, 2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(1, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(0, 2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(-5, -2), Quaternion.identity);
                Instantiate(_obstacles[0], new Vector2(-2, -4), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(-4, 3), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(2, 2), Quaternion.identity);
                Instantiate(_obstacles[1], new Vector2(3, -4), Quaternion.identity);
                break;
        }
    }
    #endregion

    #region Check for stage ending
    public void FinalChecker()
    {
        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 1 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_1_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 1 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_1_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_1_stats", 2);
            }
            _canvGoodGame.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 1 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_1_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_1_stats", 1);
            }
            _canvGoodGame.SetActive(true);
        }



        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 2 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_2_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 2 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_2_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_2_stats", 2);
            }

        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 2 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_2_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_2_stats", 1);
            }
        }



        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 3 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_3_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 3 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_3_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_3_stats", 2);
            }

        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 3 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_3_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_3_stats", 1);
            }
        }



        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 4 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_4_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 4 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_4_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_4_stats", 2);
            }

        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 4 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_4_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_4_stats", 1);
            }
        }



        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 5 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_5_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 5 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_5_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_5_stats", 2);
            }
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 5 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_5_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_5_stats", 1);
            }
        }



        if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 6 && _currentTime < _timeForStars_3)
        {
            PlayerPrefs.SetInt("Level_6_stats", 3);
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 6 && _currentTime < _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_6_stats") <= 2)
            {
                PlayerPrefs.SetInt("Level_6_stats", 2);
            }
        }
        else if (PlayerPrefs.GetInt("TotalCost") >= _scoreForWin && _currentLvl == 6 && _currentTime > _timeForStars_2)
        {
            if (PlayerPrefs.GetInt("Level_6_stats") <= 1)
            {
                PlayerPrefs.SetInt("Level_6_stats", 1);
            }
        }
    }
    #endregion

    void Update()
    {
        GoodGame();
        FinalChecker();
        LevelTimer();
        _currentScore.text = (PlayerPrefs.GetInt("TotalCost").ToString());
    }
    public void ConfigLvl(int points, float star3, float star2)
    {
        _scoreForWin = points;
        _timeForStars_3 = star3;
        _timeForStars_2 = star2;
    }
    public int LevelTimer()
    {
        _startTime += Time.deltaTime;
        _currentTime = (int)_startTime;
        _timerValue.text = (_currentTime.ToString());
        return _currentTime;
    }
    public void GoodGame()
    {
        if ((PlayerPrefs.GetInt("TotalCost") >= _scoreForWin))
        {
            _timeGoodGame.text = _currentTime + " Sec";
            _canvGoodGame.SetActive(true);
            Time.timeScale = 0;

            if (PlayerPrefs.GetInt("PreferensesSet") == 1)
            {
                _buttonsGoodGame[0].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PreferensesSet") == 2)
            {
                _buttonsGoodGame[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PreferensesSet") == 3)
            {
                _buttonsGoodGame[2].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PreferensesSet") == 4)
            {
                _buttonsGoodGame[3].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("PreferensesSet") == 5)
            {
                _buttonsGoodGame[4].SetActive(true);
            }
        }
    }

}
