using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScore : MonoBehaviour // Прикреплён к GameOver(Scene)/Hierarchy/Main Camera
{
    GameObject inpuiCurrentScoreGo; // Переменная для входящего объекта текста
    Text scoreGt; // Переменная для Tex.text

    void Update()
    {
        inpuiCurrentScoreGo = GameObject.Find("GetScore"); // Объект канваса с Текстом набранных очков
        scoreGt = inpuiCurrentScoreGo.GetComponent<Text>(); // Получение его компонента
        scoreGt.text = "Набранные очки: " + GlobalVar.value; // Обращние к static переменной GlobalVar для переноса очков между сценами
        Debug.Log(GlobalVar.value); // Проверка начисления очков в глобальную переменную
    }
}
