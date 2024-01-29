using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float  timeOfSpawnGO = 1f; // �������� ������ ��������� �������� ���� ��� ���� ���
    public static int MaxScore = 100; // ���� ���������� ����� ��� ������� ���������� ������� �� ��������� �����
    public static bool backToRoulette = true; // ��������� ��� ��������� ����� �� ����� �� ������� �� ������ Back

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Roulette");
    }
    public static void ChangeVariousMiniGame()
    {
        if (ScoreCounter.TempRouletteValue == 1)
        {
            SceneManager.LoadScene("Game_1");
        }
        else if (ScoreCounter.TempRouletteValue == 2)
        {
            SceneManager.LoadScene("Game_2");
        }
        else if (ScoreCounter.TempRouletteValue == 3)
        {
            SceneManager.LoadScene("Game_3");
        }
    }
    public void BackToTheRoullete()
    {
        if (backToRoulette)
        {
            SceneManager.LoadScene("Roulette");
        }
    }
    public void QuitTheGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
