using UnityEngine;

public class Game_3_Sct : MonoBehaviour
{
    private int _cardValue1;
    private int _cardValue2;

    [Header("StartCards")]
    public GameObject leftStartCardButton;
    public GameObject rightStartCardButton;

    [Header("LeftCardsDeck")]
    public GameObject cardAce;
    public GameObject cardJack;
    public GameObject cardQween;
    public GameObject cardKing;

    [Header("RightCardsDeck")]
    public GameObject cardAce2;
    public GameObject cardJack2;
    public GameObject cardQween2;
    public GameObject cardKing2;

    [Header("Glow")]
    public GameObject glowEffect;

    void Start()
    {      
        GameManager.backToRoulette = false;
        _cardValue1 = Random.Range(0, 4);
        _cardValue2 = Random.Range(0, 4);
    }
    public void ChooseLeftCard()
    {
        if (_cardValue1 > _cardValue2)
        {
           DelayScoreAddition();
        }
        CardsActions();
        AncillaryFunc();
    }
    public void ChooseRightCard()
    {
        if (_cardValue1 < _cardValue2)
        {
           DelayScoreAddition();
        }
        CardsActions();
        AncillaryFunc();
    }
    void CardsActions()
    {
        GameObject[] RightCardDeck = { cardAce2, cardJack2, cardQween2, cardKing2 };
        GameObject[] leftCardDeck = { cardAce, cardJack, cardQween, cardKing };
        leftCardDeck[_cardValue1].SetActive(true);
        leftStartCardButton.SetActive(false);
        RightCardDeck[_cardValue2].SetActive(true);
        rightStartCardButton.SetActive(false);
    }
    void DelayScoreAddition() => PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + (ScoreCounter.TempRouletteValue* ScoreCounter.TempRouletteValue)); // начисление глобальных очков
    public void AncillaryFunc()
    {
        glowEffect.SetActive(true);
        GameManager.backToRoulette = true;
        ScoreCounter.TempRouletteValue = 0;
    }
}
