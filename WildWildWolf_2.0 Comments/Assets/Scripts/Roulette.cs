using System.Collections;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    float speed; // рандомная скорость вращеняи рулетки
    public GameObject rouletteGO;
    public GameObject glowEffect;

    public void Spin()
    {
        if (speed == 0)
        {
            glowEffect.SetActive(false);
            PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + ScoreCounter.TempRouletteValue); // начисление глобальных очков
            ScoreCounter.TempRouletteValue = 0; // обнуление очков временной переменной 
            StartCoroutine("RouletteRotation"); // запуск колеса 
        }
    }
    public void Miltiply()
    {
        if (speed == 0 && ScoreCounter.TempRouletteValue !=0) // проверка на доступность нажания кнопки Miltiply
        {
            GameManager.ChangeVariousMiniGame(); // выбор сцены мини игры 
        }
    }
    IEnumerator RouletteRotation() // Корутина вращения и сотановки рулетки
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
