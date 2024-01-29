using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveColumn : MonoBehaviour
{
    private Vector3 _topPosition_Column_1 = new Vector3((float)Math.Round(-4f), (float)Math.Round(10f, 1), 0);
    private Vector3 _topPosition_Column_2 = new Vector3((float)Math.Round(-0.5f, 1), (float)Math.Round(10f, 1), 0);
    private Vector3 _topPosition_Column_3 = new Vector3((float)Math.Round(3f, 1), (float)Math.Round(10f, 1), 0);
    private Vector3 _topPosition_Column_4 = new Vector3((float)Math.Round(6.5f, 1), (float)Math.Round(10f, 1), 0);
    private Vector3 _topPosition_Column_5 = new Vector3((float)Math.Round(10f, 1), (float)Math.Round(10f, 1), 0);

    [SerializeField] private GameObject[] _Column_1 = new GameObject[6];
    [SerializeField] private GameObject[] _Column_2 = new GameObject[6];
    [SerializeField] private GameObject[] _Column_3 = new GameObject[6];
    [SerializeField] private GameObject[] _Column_4 = new GameObject[6];
    [SerializeField] private GameObject[] _Column_5 = new GameObject[6];
    [Space]
    [SerializeField] private GameObject _trigger1 = null;
    [SerializeField] private GameObject _trigger2 = null;
    [SerializeField] private GameObject _trigger3 = null;
    [SerializeField] private GameObject _trigger4 = null;
    [SerializeField] private GameObject _trigger5 = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _scoreMeshText = null;
    [Space]
    [SerializeField ]private float speed = 15f;

    bool column_1 = false;
    bool column_2 = false;
    bool column_3 = false;
    bool column_4 = false;
    bool column_5 = false;

    private bool _buttonActivate = false;

    float time_1;

    int time1;
    int time2;
    int time3;
    int time4;
    int time5;
    int time_2;
    int ValueFoArray_1;
    int ValueFoArray_2;
    int ValueFoArray_3;
    int ValueFoArray_4;
    int ValueFoArray_5;
     private float distance;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        PlayerPrefs.SetInt("Total_Score", 100);
        _scoreMeshText.text = PlayerPrefs.GetInt("Total_Score").ToString();
    }

    public void ButtonControl()
    {
        if (_buttonActivate == false)
        {
            _trigger1.SetActive(false);
            _trigger2.SetActive(false);
            _trigger3.SetActive(false);
            _trigger4.SetActive(false);
            _trigger5.SetActive(false);

            _buttonActivate = true;

            column_1 = false;
            column_2 = false;
            column_3 = false;
            column_4 = false;
            column_5 = false;

            Rand();
        }
    }


    void Update()
    {
        if (_buttonActivate == true)
        {
            Roll();
        }
    }

    public void Rand()
    {
        time1 = UnityEngine.Random.Range(2, 10);
        time2 = UnityEngine.Random.Range(2, 10);
        time3 = UnityEngine.Random.Range(2, 10);
        time4 = UnityEngine.Random.Range(2, 10);
        time5 = UnityEngine.Random.Range(2, 10);

        ValueFoArray_1 = UnityEngine.Random.Range(0, 6);
        ValueFoArray_2 = UnityEngine.Random.Range(0, 6);
        ValueFoArray_3 = UnityEngine.Random.Range(0, 6);
        ValueFoArray_4 = UnityEngine.Random.Range(0, 6);
        ValueFoArray_5 = UnityEngine.Random.Range(0, 6);
    }

    private void Timer()
    {
        time_1 += Time.deltaTime;
        time_2 = (int)time_1;
    }
    #region SPEED CORRECTOR
    private void FixedSpeed(GameObject[] mass)
    {
        distance = mass[5].transform.position.y - mass[4].transform.position.y;
        if (distance > -3)
        {
            mass[5].transform.Translate(0, Mathf.Round(-speed) * 0.01f * Time.deltaTime, 0);
        }
        if (distance < -3)
        {
            mass[5].transform.Translate(0, Mathf.Round(-speed) * -0.01f * Time.deltaTime, 0);
        }
        distance = mass[4].transform.position.y - mass[3].transform.position.y;
        if (distance > -3)
        {
            mass[4].transform.Translate(0, Mathf.Round(-speed) * 0.01f * Time.deltaTime, 0);
        }
        if (distance < -3)
        {
            mass[4].transform.Translate(0, Mathf.Round(-speed) * -0.01f * Time.deltaTime, 0);
        }
        distance = mass[3].transform.position.y - mass[2].transform.position.y;
        if (distance > -3)
        {
            mass[3].transform.Translate(0, Mathf.Round(-speed) * 0.01f * Time.deltaTime, 0);
        }
        if (distance < -3)
        {
            mass[3].transform.Translate(0, Mathf.Round(-speed) * -0.01f * Time.deltaTime, 0);
        }
        distance = mass[2].transform.position.y - mass[1].transform.position.y;
        if (distance > -3)
        {
            mass[2].transform.Translate(0, Mathf.Round(-speed) * 0.01f * Time.deltaTime, 0);
        }
        if (distance < -3)
        {
            mass[2].transform.Translate(0, Mathf.Round(-speed) * -0.01f * Time.deltaTime, 0);
        }
        distance = mass[1].transform.position.y - mass[0].transform.position.y;
        if (distance > -3)
        {
            mass[1].transform.Translate(0, Mathf.Round(-speed) * 0.01f * Time.deltaTime, 0);
        }
        if (distance < -3)
        {
            mass[1].transform.Translate(0, Mathf.Round(-speed) * -0.01f * Time.deltaTime, 0);
        }
    }
    #endregion
    #region SLOTS CONTROL
    public void Roll()
    {
        
        Timer();

        foreach (var item in _Column_1)
        {
            if (time_2 >= time1 && _Column_1[ValueFoArray_1].transform.position.y < 1.25f && _Column_1[ValueFoArray_1].transform.position.y > 1.1f)
            {

                column_1 = true;
                _trigger1.SetActive(true);
                break;
            }

            FixedSpeed(_Column_1);
          
            item.transform.Translate(0, Mathf.Round(-speed) * Time.deltaTime, 0);
            if (item.transform.position.y <= -8f)
            {
                item.transform.position = _topPosition_Column_1;
            }

        
        }


        foreach (var item in _Column_2)
        {
            if (time_2 >= time2 && _Column_2[ValueFoArray_2].transform.position.y < 1.25f && _Column_2[ValueFoArray_2].transform.position.y > 1.1f)
            {
                _trigger2.SetActive(true);
                column_2 = true;
                break;
            }

            FixedSpeed(_Column_2);

            item.transform.Translate(0, -speed * Time.deltaTime, 0);
            if (item.transform.position.y <= (float)Math.Round(-8f, 1))
            {
                item.transform.position = _topPosition_Column_2;
            }

        }


        foreach (var item in _Column_3)
        {
            if (time_2 >= time3 && _Column_3[ValueFoArray_3].transform.position.y < 1.25f && _Column_3[ValueFoArray_3].transform.position.y > 1.1f)
            {
                _trigger3.SetActive(true);
                column_3 = true;
                break;
            }

            FixedSpeed(_Column_3);

            item.transform.Translate(0, -speed * Time.deltaTime, 0);
            if (item.transform.position.y <= (float)Math.Round(-8f, 1))
            {
                item.transform.position = _topPosition_Column_3;
            }
        }


        foreach (var item in _Column_4)
        {

            if (time_2 >= time4 && _Column_4[ValueFoArray_4].transform.position.y < 1.25f && _Column_4[ValueFoArray_4].transform.position.y > 1.1f)
            {
                _trigger4.SetActive(true);
                column_4 = true;
                break;
            }

            FixedSpeed(_Column_4);

            item.transform.Translate(0, -speed * Time.deltaTime, 0);
            if (item.transform.position.y <= (float)Math.Round(-8f, 1))
            {
                item.transform.position = _topPosition_Column_4;
            }
        }


        foreach (var item in _Column_5)
        {

            if (time_2 >= time5 && _Column_5[ValueFoArray_5].transform.position.y < 1.25f && _Column_5[ValueFoArray_5].transform.position.y > 1.1f)
            {
                _trigger5.SetActive(true);
                column_5 = true;
                break;
            }

            FixedSpeed(_Column_5);

            item.transform.Translate(0, -speed * Time.deltaTime, 0);
            if (item.transform.position.y <= (float)Math.Round(-8f, 1))
            {
                item.transform.position = _topPosition_Column_5;
            }
        }

        if (column_1 == true && column_2 == true && column_3 == true && column_4 == true && column_5 == true)
        {

            StartCoroutine("Sum");           
            time_1 = 0;
            _buttonActivate = false;
        }
    }
    #endregion
    #region ADDING SCORES
    IEnumerator Sum()
    {
        yield return new WaitForSeconds(0.2f);
        if (PlayerPrefs.GetInt("Seven_Temp") >= 20 || PlayerPrefs.GetInt("Cherry_Temp") >= 20 || PlayerPrefs.GetInt("Grace_Temp") >= 20 || PlayerPrefs.GetInt("Lemon_Temp") >= 20 || PlayerPrefs.GetInt("Plum_Temp") >= 20 || PlayerPrefs.GetInt("Watermelon_Temp") >= 20)
        {
            yield return new WaitForSeconds(0.2f);
            PlayerPrefs.SetInt("Total_Score", PlayerPrefs.GetInt("Total_Score") + PlayerPrefs.GetInt("Seven_Temp") + PlayerPrefs.GetInt("Cherry_Temp") + PlayerPrefs.GetInt("Grace_Temp") + PlayerPrefs.GetInt("Lemon_Temp") + PlayerPrefs.GetInt("Plum_Temp") + PlayerPrefs.GetInt("Watermelon_Temp"));
            _scoreMeshText.text = PlayerPrefs.GetInt("Total_Score").ToString();
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            PlayerPrefs.SetInt("Total_Score", PlayerPrefs.GetInt("Total_Score") - 10);
            _scoreMeshText.text = PlayerPrefs.GetInt("Total_Score").ToString();
        }

        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("Seven", 0);
        PlayerPrefs.SetInt("Cherry", 0);
        PlayerPrefs.SetInt("Grace", 0);
        PlayerPrefs.SetInt("Lemon", 0);
        PlayerPrefs.SetInt("Plum", 0);
        PlayerPrefs.SetInt("Watermelon", 0);

        PlayerPrefs.SetInt("Seven_Temp", 0);
        PlayerPrefs.SetInt("Cherry_Temp", 0);
        PlayerPrefs.SetInt("Grace_Temp", 0);
        PlayerPrefs.SetInt("Lemon_Temp", 0);
        PlayerPrefs.SetInt("Plum_Temp", 0);
        PlayerPrefs.SetInt("Watermelon_Temp", 0);
    }
    #endregion
}
