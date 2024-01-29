using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // ������ �������� � GO � ������ ����� ��� ������� ������� ����� (TotalScore)

    [HideInInspector] public static float TempRouletteValue; // ���������� ������ � ���� ��������� �������� ����� �������� �� �������, � ���� ���������� �������� ���� ����, � ��� �� �������� ������ �� ��������� �����
    public static Text scoreGT; // ���������� ��� ���������� Text

    void Start()
    {
        scoreGT = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        string temp = PlayerPrefs.GetFloat("TotalScore").ToString();
        scoreGT.text = temp; // ����� ����� �� �����, ��������� ����� �� PlayerPrefs
        int temp2 = int.Parse(temp);
        if (temp2 >= GameManager.MaxScore) // �������� �� ������������ ���������� ��������� �����
        {
            SceneManager.LoadScene("Final");
            PlayerPrefs.DeleteAll(); // �������� ��������� �����
            Debug.Log(scoreGT.text);
        }
    }
}
