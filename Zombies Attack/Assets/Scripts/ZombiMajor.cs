using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombiMajor : MonoBehaviour // Прикреплён к Assets/Sprites/Zombie_Major.prefab
// Описание кода для зомби сделал только в скрипте ZombiSoldier
{
    [Header("Zombi's target")]
    public GameObject target;
    [Header("Zombi Parameters")]
    public float speed = 3f;
    public int hp = 10;
    public int killingScore = 12;
    public GameObject boomAnim;
    GameObject currentBoomAnim;
    GameObject scoreGO;
    public Text scoreGT;

    void Start()
    {
        scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
    }
    IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            StartCoroutine("DelayScene");
        }
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= Bullet.Damage();
            if (hp == 0)
            {
                Destroy(gameObject);
                Vector2 WhereToSpawn = new Vector2(transform.position.x, transform.position.y);
                currentBoomAnim = Instantiate(boomAnim, WhereToSpawn, Quaternion.identity);
                Destroy(currentBoomAnim, 3.5f);
                int score = int.Parse(scoreGT.text);
                score += killingScore;
                scoreGT.text = score.ToString();
            }
        }
    }
    void Update()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        transform.Translate(directionToTarget * speed * Time.deltaTime);
    }
}