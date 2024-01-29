using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombiesSpawner_Fixed : MonoBehaviour // ��������� � SampleScene(Scene)/Hierarchy/Main Camera
{
    [Header("Zombies Prefabs")]
    public GameObject simpleZombi; // ������ ����� - �������
    public GameObject zombiMajor; // ����� - �������
    public GameObject zombiArmored; // ������������� �����
    [Header("Spawn Variable")]
    public float rateOfSpawn = 2f; // ������� ��������� ����� ��� ������ �����, rateOfSpawn ��� � �������
    public float reductorTime = 0.3f; // ���������� rateOfSpawn - 0.1 ���
    public float reductorTimeInTime = 20f; // ����� reducturTimeInTime(rateOfSpawn - 0.1) ����������� ����� ������ �����
    private float _randX; // ���������� ��� ���������� ������ ����� �� ��� Y
    private float _randY; // ���������� ��� ���������� ������ ����� �� ��� �
    Vector2 WhereToSpawn; // �������� ��� Instantiate ��� �������� ����� ������ �����
    [Header("Spawn Point")]
    public GameObject inputSpawnPointTop; // ������� ����� ������
    public GameObject inputSpawnPointLeft; // ����� ����� ������
    public GameObject InputSpawnPointRight; // ������ ����� ������
    GameObject SpawnPointTop; // 
    GameObject SpawnPointLeft; //
    GameObject SpawnPointRight; //
    private int _whereToSpawnRandomValue; // ���������� ��� �������� ������ � ����� �� 1 ������ � ��� ������������� Random.Range(1,3)
    private int _getZombi; // ���������� ��� ��������� ���������� ����� �� 1 �� 10, ��� �� �������� ��������� ����� ����� �� �������

    GameObject scoreGO; // ����������� ������� � ������� �� �������
    public static Text scoreGT; // ���������� ��� ��������� ���������� Text �� ������� scoreGO

    GameObject[] zobbiesMass = new GameObject[3]; // ������ ��� �����
    void Start()
    {
        SpawnPointTop = inputSpawnPointTop;
        SpawnPointLeft = inputSpawnPointLeft;
        SpawnPointRight = InputSpawnPointRight;

        scoreGO = GameObject.Find("ScoreCounter"); // ��������� ������� �� �������
        scoreGT = scoreGO.GetComponent<Text>(); // ��������� ���������� �����
        scoreGT.text = "0"; // ��������� �������� �����

        zobbiesMass[0] = simpleZombi; // ������ ����� � ������
        zobbiesMass[1] = zombiMajor;
        zobbiesMass[2] = zombiArmored;

        StartCoroutine(TimeScale()); // ���������� ���������� �������� ������ ����� 
    }
    void Update()
    {
        if (!IsInvoking("Spawn"))
        {
            Invoke("Spawn", rateOfSpawn); // ��������� ������������� ������ ����� ��� � (rateOfSpawn) ������
        }
    }
    IEnumerator TimeScale() // ������� ��� ���������� �������� ������ ����� � �������� ������� ������ (reducturTimeInTime) ������
    {
        for (float i = rateOfSpawn; i >= 0.5f; i -= reductorTime)
        {
            rateOfSpawn -= 0.1f;
            yield return new WaitForSeconds(reductorTimeInTime);
        }
    }
    void Spawn() // ����� ���������� �� ����������� ��������� ����� �� �������
    {
        // ������ � ���������� ��������� ��������� �������� ������  rateOfSpawn ������ (0s.0ms)
        _whereToSpawnRandomValue = Random.Range(1, 4);
         _getZombi = Random.Range(1, 10);
         _randX = Random.Range(-7, 7);
         _randY = Random.Range(6, -2);

         // ����� ���������� ����� ������
         if (_whereToSpawnRandomValue == 1)
         {
             WhereToSpawn = new Vector2(_randX, SpawnPointTop.transform.position.y); // ����� � ������� �����
         }
         else if (_whereToSpawnRandomValue == 2)
         {
             WhereToSpawn = new Vector2(SpawnPointLeft.transform.position.x, _randY); // ����� � ����� ����� 
        }
         else if (_whereToSpawnRandomValue == 3) // ���� �� ������ 72 ������� Random.Range(1,3) ����� ������������ ��������� �������� 3, �� ������ else �� �����������
         {
             WhereToSpawn = new Vector2(SpawnPointRight.transform.position.x, _randY); // ����� � ������ ����� 
        }

        // ��������� ����� ����� �� ������� ����� ��������� ���������� 
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
