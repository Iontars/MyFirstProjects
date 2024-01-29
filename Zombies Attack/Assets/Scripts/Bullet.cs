using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // Прикреплён к Assets/Sprites/bullet.prefab
{
    public GameObject bullet; // Префаб пули 
    public float bulletSpeed = 10f; // Скорость пули
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombi")
        {
            Destroy(bullet.gameObject); // При попадании в любого зомби пуля разрушается
        }
    } 
    public static int Damage() // Использую Метод а не поле для получения урона из пули, потому что метод можно скорректировать при желании с разными входящими аргументами
    {
        int outDamage = 1; // Переменная с уроном пули
        return outDamage; // Возвращаем
    }
    void Update()
    {
        // через transform.up получается не совсем некоректный полёт пули, если выйдти за углы ограничения поворота ГГ, но тут дело скорее всего в точке спавна на кончике дула
        transform.Translate(transform.up  * bulletSpeed * Time.deltaTime); 
    }
}
