using UnityEngine;

public class Game_1_Sct : MonoBehaviour
{
    private int _cardValue; // ��������� ����������

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
    public void ChooseHearts() // ����� ����� �����
    {
        LeftButtonGlow.SetActive(true);
        if (_cardValue == 1) 
        {
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO);
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO);
        Invoke("CardsActions", GameManager.timeOfSpawnGO); // ����� ����� �� ������� ����
    }
    public void ChooseDiamonds()  // ����� ����� ����
    {
        RightButtonGlow.SetActive(true);
        if (_cardValue == 2)
        {
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO); // ���������� ���������� �����
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO); // �������������� ����������
        Invoke("CardsActions", GameManager.timeOfSpawnGO); // ����� ����� �� ������� ����
    }
    void DelayScoreAddition() => PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + (ScoreCounter.TempRouletteValue * ScoreCounter.TempRouletteValue)); // ���������� ���������� �����
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
        LeftButtonGlow.SetActive(false); // ������ �� ����������
        RightButtonGlow.SetActive(false);
        BottomButtonGlow.SetActive(true);
        GameManager.backToRoulette = true; // ��������� ����������� ������ �� ������ Back
        ScoreCounter.TempRouletteValue = 0; // ��������� ����� ��������� ���������� 
    }
}
