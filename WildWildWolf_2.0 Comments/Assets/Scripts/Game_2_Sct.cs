using UnityEngine;

public class Game_2_Sct : MonoBehaviour
{
    private int _cubeValue;

    [Header("Cubes")]
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;

    [Header("SpawnPointForCubes")]
    public GameObject spawpPoint;

    [Header("Glow")]
    public GameObject glowEffect;

    GameObject[] cubeArray = new GameObject[6];

    void Start()
    {
        GameManager.backToRoulette = false;
        cubeArray[0] = cube1;
        cubeArray[1] = cube2;
        cubeArray[2] = cube3;
        cubeArray[3] = cube4;
        cubeArray[4] = cube5;
        cubeArray[5] = cube6;
        _cubeValue = Random.Range(0, 6);
    }
    public void Choose_1_3()
    {
        if (_cubeValue >=0 && _cubeValue <=2)
        {
            
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO);
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO);
    }
    public void Choose_4_6()
    {
        if (_cubeValue >= 3 && _cubeValue <= 5)
        {
            
            Invoke("DelayScoreAddition", GameManager.timeOfSpawnGO);        
        }
        Invoke("AncillaryFunc", GameManager.timeOfSpawnGO);
    }
    void DelayScoreAddition() => PlayerPrefs.SetFloat("TotalScore", PlayerPrefs.GetFloat("TotalScore") + (ScoreCounter.TempRouletteValue* ScoreCounter.TempRouletteValue)); // начисление глобальных очков
    void AncillaryFunc()
    {
        cubeArray[_cubeValue].SetActive(true);
        glowEffect.SetActive(true);
        GameManager.backToRoulette = true;
        ScoreCounter.TempRouletteValue = 0;
    }       
}
