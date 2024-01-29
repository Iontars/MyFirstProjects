using UnityEngine;

public class Game_1_Sct : MonoBehaviour
{
    private int _cardValue; // рандомная переменная

    [Header("Cards")]
    public GameObject GOcarHearts;
    public GameObject GOcardDiamonds;

    [Header("Glow")]
    public GameObject LeftButtonGlow;
    public GameObject RightButtonGlow;
    public GameObject BottomButtonGlow;

    void Start()
    {
        GameManager.backToRoulette = false; 
        _cardValue = Random.Range(1, 3); 
    }
    public void ChooseHearts() // выбор карты черви
    {
        LeftButtonGlow.SetActive(true);
        if (_cardValue == 1) 
        {
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO);
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO);
        Invoke("CardsActions", GameManager.timeOfSpawnGO); // спавн карты на игровое поле
    }
    public void ChooseDiamonds()  // выбор карты буби
    {
        RightButtonGlow.SetActive(true);
        if (_cardValue == 2)
        {
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO); // начисление глобальных очков
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO); // дополнительный функционал
        Invoke("CardsActions", GameManager.timeOfSpawnGO); // спавн карты на игровое поле
    }
    void DelayScoreAddition() => PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + (ScoreCounter.TempRouletteValue * ScoreCounter.TempRouletteValue)); // начисление глобальных очков
    void CardsActions()
    {
        if (_cardValue == 1)
        {
            GOcarHearts.SetActive(true);
        }
        else 
        {
            GOcardDiamonds.SetActive(true);
        }
    }
    void AncillaryFunc()
    {      
        LeftButtonGlow.SetActive(false); // работа со подсветкой
        RightButtonGlow.SetActive(false);
        BottomButtonGlow.SetActive(true);
        GameManager.backToRoulette = true; // включение возможности нажать на кнопку Back
        ScoreCounter.TempRouletteValue = 0; // обнуление очков временной переменной 
    }
}
