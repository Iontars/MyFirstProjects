using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombiesSpawner_Fixed : MonoBehaviour // Прикреплён к SampleScene(Scene)/Hierarchy/Main Camera
{
    [Header("Zombies Prefabs")]
    public GameObject simpleZombi; // Префаб Зомби - рядовой
    public GameObject zombiMajor; // Зомби - бывалый
    public GameObject zombiArmored; // Бронированный зомби
    [Header("Spawn Variable")]
    public float rateOfSpawn = 2f; // Частота появления зомби при старте сцены, rateOfSpawn раз в секунду
    public float reductorTime = 0.3f; // Уменьшатор rateOfSpawn - 0.1 сек
    public float reductorTimeInTime = 20f; // Через reducturTimeInTime(rateOfSpawn - 0.1) уменьшается время спавна зомби
    private float _randX; // Переменная для рандомного спавна зомби по оси Y
    private float _randY; // Переменная для рандомного спавна зомби по оси Х
    Vector2 WhereToSpawn; // Аргумент для Instantiate для указания места спавна зомби
    [Header("Spawn Point")]
    public GameObject inputSpawnPointTop; // Верхняя точка спавна
    public GameObject inputSpawnPointLeft; // Левая точка спавна
    public GameObject InputSpawnPointRight; // Правая точка спавна
    GameObject SpawnPointTop; // 
    GameObject SpawnPointLeft; //
    GameObject SpawnPointRight; //
    private int _whereToSpawnRandomValue; // Переменная для имитации спавна в одной из 1 сторон в ней присваивается Random.Range(1,3)
    private int _getZombi; // Переменная для получения рандомного числа от 1 до 10, что бы получить случайный спавн зомби из массива

    GameObject scoreGO; // Подключение объекта с текстом на канвасе
    public static Text scoreGT; // Переменная для получения компонента Text из объекта scoreGO

    GameObject[] zobbiesMass = new GameObject[3]; // Массив для зомби
    void Start()
    {
        SpawnPointTop = inputSpawnPointTop;
        SpawnPointLeft = inputSpawnPointLeft;
        SpawnPointRight = InputSpawnPointRight;

        scoreGO = GameObject.Find("ScoreCounter"); // Получение объекта из канваса
        scoreGT = scoreGO.GetComponent<Text>(); // Получение компонента текст
        scoreGT.text = "0"; // Начальное значение очков

        zobbiesMass[0] = simpleZombi; // Запись зомби в массив
        zobbiesMass[1] = zombiMajor;
        zobbiesMass[2] = zombiArmored;

        StartCoroutine(TimeScale()); // Запускатор увеличения быстроты спавна зомби 
    }
    void Update()
    {
        if (!IsInvoking("Spawn"))
        {
            Invoke("Spawn", rateOfSpawn); // Стартовая инициализация спавна зомби раз в (rateOfSpawn) секунд
        }
    }
    IEnumerator TimeScale() // Функция для увеличения быстроты спавна зомби с течением времени каждые (reducturTimeInTime) секунд
    {
        for (float i = rateOfSpawn; i >= 0.5f; i -= reductorTime)
        {
            rateOfSpawn -= 0.1f;
            yield return new WaitForSeconds(reductorTimeInTime);
        }
    }
    void Spawn() // Метод отвечающий за рандомность появления зомби из массива
    {
        // Запись в переменные различных рандомных значений каждые  rateOfSpawn секунд (0s.0ms)
        _whereToSpawnRandomValue = Random.Range(1, 4);
         _getZombi = Random.Range(1, 10);
         _randX = Random.Range(-7, 7);
         _randY = Random.Range(6, -2);

         // Выбор рандомного места спавна
         if (_whereToSpawnRandomValue == 1)
         {
             WhereToSpawn = new Vector2(_randX, SpawnPointTop.transform.position.y); // Спавн в верхнйе точке
         }
         else if (_whereToSpawnRandomValue == 2)
         {
             WhereToSpawn = new Vector2(SpawnPointLeft.transform.position.x, _randY); // Спавн в левой точке 
        }
         else if (_whereToSpawnRandomValue == 3) // если на строке 72 сделать Random.Range(1,3) когда выкидывается рандомное значение 3, то просто else не выполняется
         {
             WhereToSpawn = new Vector2(SpawnPointRight.transform.position.x, _randY); // Спавн в правой точке 
        }

        // Рандомный выбор зомби из массива через рандомную переменную 
        if (_getZombi > 1 && _getZombi <= 6) //
        {
            Instantiate(zobbiesMass[0], WhereToSpawn, Quaternion.identity);
        }
        else if (_getZombi > 6 && _getZombi <= 9)
        {
            Instantiate(zobbiesMass[1], WhereToSpawn, Quaternion.identity);
        }
        else
        {
            Instantiate(zobbiesMass[2], WhereToSpawn, Quaternion.identity);
        }
    }
}
