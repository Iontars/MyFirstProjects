using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _canvInfo = null;
    [SerializeField] private GameObject _goToLevel_1 = null;
    [SerializeField] private GameObject _goToLevel_2 = null;
    [SerializeField] private GameObject _goToLevel_3 = null;
    [SerializeField] private GameObject _goToLevel_4 = null;
    [SerializeField] private GameObject _goToLevel_5 = null;
    [SerializeField] private GameObject _goToLevel_6 = null;
    [Space]
    [SerializeField] private Text _infoFo_3_Stars = null;
    [SerializeField] private Text _infoFo_2_Stars = null;
    [Space]
    [SerializeField] private GameObject _canvPause = null;

    [SerializeField] private Image _volumeButtonImage = null;
    [SerializeField] private Sprite sprtVolumeOFF = null;
    [SerializeField] private Sprite sprtVolumeON = null;

    public int OneStar => _oneStar;
    private readonly int _oneStar = 1;

    public int TwoStar => _twoStar;
    private readonly int _twoStar = 2;

    public int ThreeStar => _threeStar;
    private readonly int _threeStar = 3;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        PlayerPrefs.SetInt("Level_1_ScoreInfo", 15);    PlayerPrefs.SetFloat("Lvl_1_TimeFor_3_Stars", 30f);    PlayerPrefs.SetFloat("Lvl_1_TimeFor_2_Stars", 45f);
        PlayerPrefs.SetInt("Level_2_ScoreInfo", 25);    PlayerPrefs.SetFloat("Lvl_2_TimeFor_3_Stars", 50f);    PlayerPrefs.SetFloat("Lvl_2_TimeFor_2_Stars", 65f);
        PlayerPrefs.SetInt("Level_3_ScoreInfo", 35);    PlayerPrefs.SetFloat("Lvl_3_TimeFor_3_Stars", 70f);    PlayerPrefs.SetFloat("Lvl_3_TimeFor_2_Stars", 85f); 
        PlayerPrefs.SetInt("Level_4_ScoreInfo", 45);    PlayerPrefs.SetFloat("Lvl_4_TimeFor_3_Stars", 90f);    PlayerPrefs.SetFloat("Lvl_4_TimeFor_2_Stars", 105f);
        PlayerPrefs.SetInt("Level_5_ScoreInfo", 55);    PlayerPrefs.SetFloat("Lvl_5_TimeFor_3_Stars", 110f);   PlayerPrefs.SetFloat("Lvl_5_TimeFor_2_Stars", 125f);
        PlayerPrefs.SetInt("Level_6_ScoreInfo", 65);    PlayerPrefs.SetFloat("Lvl_6_TimeFor_3_Stars", 130f);   PlayerPrefs.SetFloat("Lvl_6_TimeFor_2_Stars", 145f);
    }

    public void ShowInfoAboutLvl(string sceneName)
    {
        _canvInfo.SetActive(true);

        switch(sceneName)
        {
            case "Level_1":
                _goToLevel_1.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_1_ScoreInfo") + " POINTS COLLECT\n IN  "+ PlayerPrefs.GetFloat("Lvl_1_TimeFor_3_Stars") +" SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_1_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_1_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 1);
                break;
            case "Level_2":
                _goToLevel_2.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_2_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_2_TimeFor_3_Stars") + " SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_2_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_2_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 2);
                break;
            case "Level_3":
                _goToLevel_3.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_3_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_3_TimeFor_3_Stars") + " SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_3_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_3_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 3);
                break;
            case "Level_4":
                _goToLevel_4.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_4_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_4_TimeFor_3_Stars") + " SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_4_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_4_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 4);
                break;
            case "Level_5":
                _goToLevel_5.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_5_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_5_TimeFor_3_Stars") + " SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_5_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_5_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 5);
                break;
            case "Level_6":
                _goToLevel_6.SetActive(true);
                _infoFo_3_Stars.text = (PlayerPrefs.GetInt("Level_6_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_6_TimeFor_3_Stars") + " SECONDS");
                _infoFo_2_Stars.text = (PlayerPrefs.GetInt("Level_6_ScoreInfo") + " POINTS COLLECT\n IN  " + PlayerPrefs.GetFloat("Lvl_6_TimeFor_2_Stars") + " SECONDS");
                PlayerPrefs.SetInt("PreferensesSet", 6);
                break;
        }
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
    public void ChooseScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }
    public void MainMenuSelections()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void PauseMode()
    {
        _canvPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseModeOFF()
    {
        _canvPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void AudioController()
    {
        if (AudioListener.volume == 1)
        {
            _volumeButtonImage.sprite = sprtVolumeOFF;
            Debug.Log("off");
            AudioListener.volume = 0;
        }
        else if(AudioListener.volume == 0)
        {
            _volumeButtonImage.sprite = sprtVolumeON;
            AudioListener.volume = 1;
            Debug.Log("on");
        }      
    }
    public void Web()
    {
        Application.OpenURL("https://sites.google.com/view/money-jungle/");
    }
    public void NextScene()
    {
        if (PlayerPrefs.GetInt("PreferensesSet") == 1)
        {
            PlayerPrefs.SetInt("PreferensesSet", 2);
        }
        else if (PlayerPrefs.GetInt("PreferensesSet") == 2)
        {
            PlayerPrefs.SetInt("PreferensesSet", 3);
        }
        else if (PlayerPrefs.GetInt("PreferensesSet") == 3)
        {
            PlayerPrefs.SetInt("PreferensesSet", 4);
        }
        else if (PlayerPrefs.GetInt("PreferensesSet") == 4)
        {
            PlayerPrefs.SetInt("PreferensesSet", 5);
        }
        else if (PlayerPrefs.GetInt("PreferensesSet") == 5)
        {
            PlayerPrefs.SetInt("PreferensesSet", 6);
        }
    }
}
