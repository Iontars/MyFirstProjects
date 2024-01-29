using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // скрипт привязан к GO в каждой сцене где имеентя счётчик очков (TotalScore)

    [HideInInspector] public static float TempRouletteValue; // переменная хранит в себе временные значения чисел выпавших на рулетке, с этой переменной работают мини игры, а так же загрузка комнат по выпавшему числу
    public static Text scoreGT; // переменная для компонента Text

    void Start()
    {
        scoreGT = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        string temp = PlayerPrefs.GetFloat("TotalScore").ToString();
        scoreGT.text = temp; // вывод очков на экран, получение даных из PlayerPrefs
        int temp2 = int.Parse(temp);
        if (temp2 >= GameManager.MaxScore) // проверка на максимальное количество набранных очков
        {
            SceneManager.LoadScene("Final");
            PlayerPrefs.DeleteAll(); // удаление набранных очков
            Debug.Log(scoreGT.text);
        }
    }
}
