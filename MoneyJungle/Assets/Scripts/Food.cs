using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Collider2D gridArea = null;
    [SerializeField] private SpriteRenderer rendr = null;
    [SerializeField] private Sprite sprt = null;
    [SerializeField] private Sprite sprt2 = null;

    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        RandomizeCoin();
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
    private void RandomizeCoin()
    {
        int randValue = Random.Range(1, 3);
        if (randValue == 1)
        {
            PlayerPrefs.SetInt("CurrentCost", 2);
            rendr.sprite = sprt;
        }
        else if (randValue == 2)
        {
            PlayerPrefs.SetInt("CurrentCost", 5);
            rendr.sprite = sprt2;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            RandomizePosition();
        }
        PlayerPrefs.SetInt("TotalCost", PlayerPrefs.GetInt("TotalCost") + PlayerPrefs.GetInt("CurrentCost"));
        RandomizePosition();
    }
}
