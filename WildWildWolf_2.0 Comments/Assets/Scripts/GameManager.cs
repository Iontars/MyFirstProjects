using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float  timeOfSpawnGO = 1f; // задержка спавна атрибутов игрового пол€ дл€ мини игр
    public static int MaxScore = 100; // макс количество очков при котором происходит переход на финальную сцену
    public static bool backToRoulette = true; // разрешает или запрещает выход из сцены по нажанию на кнопку Back

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
