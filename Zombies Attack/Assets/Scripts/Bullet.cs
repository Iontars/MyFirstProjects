using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // ��������� � Assets/Sprites/bullet.prefab
{
    public GameObject bullet; // ������ ���� 
    public float bulletSpeed = 10f; // �������� ����
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombi")
        {
            Destroy(bullet.gameObject); // ��� ��������� � ������ ����� ���� �����������
        }
    } 
    public static int Damage() // ��������� ����� � �� ���� ��� ��������� ����� �� ����, ������ ��� ����� ����� ��������������� ��� ������� � ������� ��������� �����������
    {
        int outDamage = 1; // ���������� � ������ ����
        return outDamage; // ����������
    }
    void Update()
    {
        // ����� transform.up ���������� �� ������ ����������� ���� ����, ���� ������ �� ���� ����������� �������� ��, �� ��� ���� ������ ����� � ����� ������ �� ������� ����
        transform.Translate(transform.up  * bulletSpeed * Time.deltaTime); 
    }
}
