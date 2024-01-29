using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombiSoldier : MonoBehaviour // ��������� � Assets/Sprites/Zombie_Soldier.prefab
{
    [Header("Zombi's target")]
    public GameObject target; // ������ �������� ����� ��� ����������� ������
    [Header("Zombi Parameters")]
    public float speed = 2f; // �������� �����
    public int hp = 10; // �������� �����
    public int killingScore = 7; // ���� �� �������� �����
    public GameObject boomAnim; // �������� ������ �� ���������� ���������
    GameObject currentBoomAnim; // ������ ��� ������ ��������� ������� �� ���������� ���������
    GameObject scoreGO; // ����������� ������� � ������� �� �������
    [HideInInspector]
    public Text scoreGT; // ���������� ��� ��������� ���������� Text �� ������� scoreGO

    void Start()
    {     
        scoreGO = GameObject.Find("ScoreCounter"); // ����� ������� � ������� � �������
        scoreGT = scoreGO.GetComponent<Text>(); // ��������� ���������� ��xt
    }
    IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }

    public void OnCollisionEnter(Collision collision) // ��������� �� ��������
    {
        if (collision.gameObject.tag == "Hero")
        {
            StartCoroutine("DelayScene"); // �������� ��� �������� ����� ����� 
        }
        if (collision.gameObject.tag == "Bullet")
        {            
            hp -= Bullet.Damage(); // �������� ���� �� ���� �������� �� ������ ����
            if (hp == 0)
            {
                Destroy(gameObject); // �������� ����� �� �����
                Vector2 WhereToSpawn = new Vector2(transform.position.x, transform.position.y); // ����� ������ ��� �������� ������, �������� ����� ���� ��� �� ���������� ��������
                currentBoomAnim = Instantiate(boomAnim, WhereToSpawn, Quaternion.identity); // ����� �������� ������
                Destroy(currentBoomAnim, 3.5f); // �������� �������� ������ �� �����, �� ���� �������, ��� ����� ������ ���������� �� ����� ������ �� ��������� ������ � �������������
                int score = int.Parse(scoreGT.text); // ������� �� ������� � ���
                score += killingScore; // ������ ����� � ����������
                scoreGT.text = score.ToString(); // �������� �������
            }
        }
    }
   void Update()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized; // ������������� �������� 
        transform.Translate(directionToTarget * speed * Time.deltaTime); // ������������ ����������� ������� � ����
    }
}
