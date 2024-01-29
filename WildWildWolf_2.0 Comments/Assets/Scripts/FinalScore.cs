using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // канвас с текстом на финальном экране
    private Text scoreGT; 
    void Start()
    {
        scoreGT = gameObject.GetComponent<Text>();
        scoreGT.text = ScoreCounter.scoreGT.text;
    }
}
