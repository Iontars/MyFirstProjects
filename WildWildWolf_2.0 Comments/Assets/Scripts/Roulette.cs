using System.Collections;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    float speed; // ��������� �������� �������� �������
    public GameObject rouletteGO;
    public GameObject glowEffect;

    public void Spin()
    {
        if (speed == 0)
        {
            glowEffect.SetActive(false);
            PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + ScoreCounter.TempRouletteValue); // ���������� ���������� �����
            ScoreCounter.TempRouletteValue = 0; // ��������� ����� ��������� ���������� 
            StartCoroutine("RouletteRotation"); // ������ ������ 
        }
    }
    public void Miltiply()
    {
        if (speed == 0 && ScoreCounter.TempRouletteValue !=0) // �������� �� ����������� ������� ������ Miltiply
        {
            GameManager.ChangeVariousMiniGame(); // ����� ����� ���� ���� 
        }
    }
    IEnumerator RouletteRotation() // �������� �������� � ��������� �������
    {
        speed = Random.Range(2.0f, 8.0f);
        for (float i = speed; i >= 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            rouletteGO.transform.Rotate(0f, 0f, i);     
        }
        speed = 0;
        glowEffect.SetActive(true);
    }
}
