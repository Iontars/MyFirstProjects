using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private Text _totalScore = null;

    void Update()
    {
        _totalScore.text = Ball.points.ToString();
    }
}
