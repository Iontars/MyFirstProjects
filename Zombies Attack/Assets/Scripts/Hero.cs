using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour // Прикреплен к SampleScene/Hierarchy/Hero
{
    [Header("Hero main parameters")]
    public float rateOfFire = 0.1f; // Скорострельность, инспектор
    public float speedRotate = 200f; // Скорость поворота героя
    [Space]
    public GameObject inputBullet; // Пуля префаб
    public GameObject spawnPoint; // Точка спавна пули отностительно Героя
    public GameObject BoomAnim; // Префаб анимации взрыва
    GameObject currentBoomAnim; // анимация взрыва
    GameObject bullet; // Переменная под созданные пули
    readonly float angleStopLeft = 220f; // Переменная дял оганичения угла поворота Героя по оси Z (лево)
    readonly float angleStopRight = 140f; // Переменная дял оганичения угла поворота Героя по оси Z (право)

    void Start()
    {
         Cursor.visible = false; // Прячим курсор
    }
    void Strike() // Метод отвечающий за спавн и разрушение пули через 1.5 секунды
    {
        Vector3 bulletPosition = spawnPoint.transform.position; // Присваивание значения аргументу метода Instantiate спавна пули, отвечающему за позицию спавна пули
        bullet = Instantiate(inputBullet, bulletPosition, transform.rotation.normalized); // Инициализация префаба пули 
        Destroy(bullet, 2f); // Саморазрушение пули через 2 сек
    }
    void RotateHeroForPC() // Управление для десктоп версии
    {
        float mX = Input.GetAxis("Mouse X");
        float currentZ = GetComponent<Transform>().rotation.eulerAngles.z;
        if (currentZ > angleStopLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleStopLeft); // ограничитель вращения против часовой стрелки
        }
        else if (currentZ < angleStopRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleStopRight); // ограничитель вращения по часовой стрелки
        }
        transform.Rotate(0, 0, -mX * speedRotate * Time.deltaTime, Space.World);

        // Попытка реализовать красиво через Mathf.Clamp не получилась, персонаж начинает самопроизвольно крутиться и тупить
        //float z = Mathf.Clamp(transform.rotation.z + Input.GetAxis("Mouse X") * speedRotate * Time.deltaTime, 220, 140);
        //transform.Rotate(0, 0, z)
    }
    void RotateHeroForMobile() // Управление для мобилок
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // Присваивание позиции тапа 
            Vector2 direction = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y); // Точка на экране куда смотреть
            transform.up = -direction; // Смотрим, значение отрицательное из за постановки камеры
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombi")
        {
            Destroy(gameObject);
            Vector2 WhereToSpawn = new Vector2(transform.position.x, transform.position.y);
            currentBoomAnim = Instantiate(BoomAnim, WhereToSpawn, Quaternion.identity); // Спавн анимации взрыва
            Destroy(currentBoomAnim, 3.5f);
        }
    }
    void Update()
    {
        RotateHeroForPC(); // Запуск управления для десктоп
        RotateHeroForMobile(); // Запуск управления для мобилок
        // Скорострельность
        if (!IsInvoking("Strike"))
        {
            Invoke("Strike", rateOfFire); // Выстрелов rateOfFire в секунду
        }
    }
}
