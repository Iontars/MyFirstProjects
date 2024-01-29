using UnityEngine;

public class RouletteTrigger : MonoBehaviour
{

    // триггер на вращение рулетки передающий значения во временную переменную ScoreCounter.TempRouletteValue
    void OnTriggerEnter2D(Collider2D  col)
    {
        if (col.gameObject.tag == "Number_1")
        {
            ScoreCounter.TempRouletteValue = 1;
        }
        else if (col.gameObject.tag == "Number_2")
        {
            ScoreCounter.TempRouletteValue = 2;
        }
        else if (col.gameObject.tag == "Number_3")
        {
            ScoreCounter.TempRouletteValue = 3;
        }
    }
}
