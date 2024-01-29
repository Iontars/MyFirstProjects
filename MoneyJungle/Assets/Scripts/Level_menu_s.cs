using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_menu_s : MonoBehaviour
{
    [SerializeField] private GameManager _info = null;
    [Space]
    #region "Buttons Fields"
    [SerializeField] private Button _buttonLevel_2 = null;
    [SerializeField] private Button _buttonLevel_3 = null;
    [SerializeField] private Button _buttonLevel_4 = null;
    [SerializeField] private Button _buttonLevel_5 = null;
    [SerializeField] private Button _buttonLevel_6 = null;
    [Space]
    [SerializeField] private Image _buttonLevel_2_Image = null;
    [SerializeField] private Image _buttonLevel_3_Image = null;
    [SerializeField] private Image _buttonLevel_4_Image = null;
    [SerializeField] private Image _buttonLevel_5_Image = null;
    [SerializeField] private Image _buttonLevel_6_Image = null;
    [Space]
    [SerializeField] private Sprite activeLevelImage = null;
    [Space]                                            
    #endregion

    [SerializeField] private GameObject[] stars = null;


    void Start()
    {

        // for Tests
        /*PlayerPrefs.SetInt("Level_1_stats", 1);
        PlayerPrefs.SetInt("Level_2_stats", 1);
        PlayerPrefs.SetInt("Level_3_stats", 1);
        PlayerPrefs.SetInt("Level_4_stats", 1);
        PlayerPrefs.SetInt("Level_5_stats", 1);
        PlayerPrefs.SetInt("Level_6_stats", 1);*/

        CheckLevelInfo(stars[0], stars[1], stars[2], _buttonLevel_2, _buttonLevel_2_Image, PlayerPrefs.GetInt("Level_1_stats"));
        CheckLevelInfo(stars[3], stars[4], stars[5], _buttonLevel_3, _buttonLevel_3_Image, PlayerPrefs.GetInt("Level_2_stats"));
        CheckLevelInfo(stars[6], stars[7], stars[8], _buttonLevel_4, _buttonLevel_4_Image, PlayerPrefs.GetInt("Level_3_stats"));
        CheckLevelInfo(stars[9], stars[10], stars[11], _buttonLevel_5, _buttonLevel_5_Image, PlayerPrefs.GetInt("Level_4_stats"));
        CheckLevelInfo(stars[12], stars[13], stars[14], _buttonLevel_6, _buttonLevel_6_Image, PlayerPrefs.GetInt("Level_5_stats"));
        CheckLevelInfo(stars[15], stars[16], stars[17], _buttonLevel_6, _buttonLevel_6_Image, PlayerPrefs.GetInt("Level_6_stats"));
    }
    void CheckLevelInfo(GameObject @object_1_star, GameObject @object_2_star, GameObject @object_3_star, Button but, Image img, int level)
    {
        if (level >= _info.OneStar)
        {
            but.enabled = true;
            img.sprite = activeLevelImage;
        }
        if (level == _info.OneStar)
        {
            @object_1_star.SetActive(true);
        }
        else if (level == _info.TwoStar)
        {
            @object_1_star.SetActive(true);
            @object_2_star.SetActive(true);
        }
        else if (level == _info.ThreeStar)
        {
            @object_1_star.SetActive(true);
            @object_2_star.SetActive(true);
            @object_3_star.SetActive(true);
        }
    }
}
