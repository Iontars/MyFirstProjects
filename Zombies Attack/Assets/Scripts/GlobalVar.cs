using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalVar : MonoBehaviour // ���������
{
    [HideInInspector] // �������� ���� � ����������
    public static string value; // ���������� ���������� � ������� �������� �������� � ��������� ����� �� ������ ������� �������� �����
    void Update()
    {
       value = ZombiesSpawner_Fixed.scoreGT.text; // ������������ ��������
    }
}
