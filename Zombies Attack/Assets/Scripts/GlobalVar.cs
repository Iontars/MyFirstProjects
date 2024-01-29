using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalVar : MonoBehaviour // Бездомный
{
    [HideInInspector] // Сокрытие поля в инспекторе
    public static string value; // Глобальная переменная в которую приходят значения о набранных очках из текста канваса основной сцены
    void Update()
    {
       value = ZombiesSpawner_Fixed.scoreGT.text; // Присваивание значений
    }
}
