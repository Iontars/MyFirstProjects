using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverScore : MonoBehaviour // ��������� � GameOver(Scene)/Hierarchy/Main Camera
{
    GameObject inpuiCurrentScoreGo; // ���������� ��� ��������� ������� ������
    Text scoreGt; // ���������� ��� Tex.text

    void Update()
    {
        inpuiCurrentScoreGo = GameObject.Find("GetScore"); // ������ ������� � ������� ��������� �����
        scoreGt = inpuiCurrentScoreGo.GetComponent<Text>(); // ��������� ��� ����������
        scoreGt.text = "��������� ����: " + GlobalVar.value; // �������� � static ���������� GlobalVar ��� �������� ����� ����� �������
        Debug.Log(GlobalVar.value); // �������� ���������� ����� � ���������� ����������
    }
}
