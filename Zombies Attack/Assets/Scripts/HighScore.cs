using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    //public GameObject inputScore;
   // public GameObject currentScore;
    Text inputCurrentScore;
    GameObject inputCurrentGoScore;

    static Text setHighScore;
    GameObject getGoHighScore;

    void Start()
    {

        

    }


    void Update()
    {
        inputCurrentGoScore = GameObject.Find("ScoreCounter");
        inputCurrentScore = inputCurrentGoScore.GetComponent<Text>();

        getGoHighScore = GameObject.Find("HighScore");
        setHighScore = getGoHighScore.GetComponent<Text>();
        setHighScore.text = inputCurrentScore.text;



    }
}
