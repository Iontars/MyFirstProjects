using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombiSoldier : MonoBehaviour // Прикреплён к Assets/Sprites/Zombie_Soldier.prefab
{
    [Header("Zombi's target")]
    public GameObject target; // Пребаф главного героя под управлением игрока
    [Header("Zombi Parameters")]
    public float speed = 2f; // Скорость зомби
    public int hp = 10; // Здоровье зомби
    public int killingScore = 7; // Очки за убийство зомби
    public GameObject boomAnim; // Входящий префаб со спрайтовой анимацией
    GameObject currentBoomAnim; // объект для записи входящего префаба со спрайтовой анимацией
    GameObject scoreGO; // Подключение объекта с текстом на канвасе
    [HideInInspector]
    public Text scoreGT; // Переменная для получения компонента Text из объекта scoreGO

    void Start()
    {     
        scoreGO = GameObject.Find("ScoreCounter"); // Поиск объекта с текстом в канвасе
        scoreGT = scoreGO.GetComponent<Text>(); // Получение компонента теxt
    }
    IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }

    public void OnCollisionEnter(Collision collision) // тригггеры на коллизию
    {
        if (collision.gameObject.tag == "Hero")
        {
            StartCoroutine("DelayScene"); // Корутина для задержки смены сцены 
        }
        if (collision.gameObject.tag == "Bullet")
        {            
            hp -= Bullet.Damage(); // Входящий урон от пули получаем из метода пули
            if (hp == 0)
            {
                Destroy(gameObject); // Удаление зомби со сцены
                Vector2 WhereToSpawn = new Vector2(transform.position.x, transform.position.y); // Точка спавна для анимации взрыва, наверное можно было как то локаничней записать
                currentBoomAnim = Instantiate(boomAnim, WhereToSpawn, Quaternion.identity); // Спавн анимации взрыва
                Destroy(currentBoomAnim, 3.5f); // Удаление анимации взрыва со сцены, не знаю способа, как можно просто заспавнить на сцену префаб на несколько секунд и самоудалиться
                int score = int.Parse(scoreGT.text); // Парсинг из стринга в инт
                score += killingScore; // Запись очков в переменную
                scoreGT.text = score.ToString(); // Обратный парсинг
            }
        }
    }
   void Update()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized; // Корректировка движения 
        transform.Translate(directionToTarget * speed * Time.deltaTime); // Динамическое меремещение объекта к цели
    }
}
