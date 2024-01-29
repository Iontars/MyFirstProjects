using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private Text _score = null;
    [SerializeField] private GameObject _power = null;
    [SerializeField] private GameObject _ding = null;
    


    private Vector3 _vecPower;
    private Vector3 _moveToPoint;
    private Vector3 _startPointForBall;
    private Vector3 _startLocalScaleForBall;

    public static int points = 0;

    private bool _switch = false;
    private bool _blockRepeatClick = false;
    private float speed = 0.3f;
    private float _multiplyPowerSpeed = 0.3f;
    private int tempScore;
    private int maxScore = 6;



    private void Start()
    {
        _vecPower = _power.transform.position;
        _startPointForBall = transform.position;
        _startLocalScaleForBall = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pin_1")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_1").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Pin_2")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_2").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Pin_3")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_3").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Pin_4")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_4").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Pin_5")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_5").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Pin_6")
        {
            tempScore += 1;
            points += 1;
            _score.text = points.ToString();
            collision.gameObject.SetActive(false);
            GameObject.Find("pin_6").SetActive(false);
            StartCoroutine(Ding());
        }
        if (collision.gameObject.tag == "Wall")
        {
            _switch = true;
            _moveToPoint = Vector3.zero;
            transform.localScale = _startLocalScaleForBall;
            transform.position = _startPointForBall;           
            speed = _multiplyPowerSpeed;
        }
    }

    void Update()
    {
        if (points == maxScore)
        {
            SceneManager.LoadScene(2);           
        }

        if (Input.GetMouseButton(0))
        {
            if (speed >= 0.1f && speed <=2f)
            {
                speed += _multiplyPowerSpeed * Time.deltaTime;
                _power.transform.Translate(0, speed / 2f * Time.deltaTime, 0);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            _switch = false;
            tempScore = 0;
            _power.transform.position = _vecPower;
            Vector2 mousePos = Input.mousePosition;
            _moveToPoint = Camera.main.ScreenToWorldPoint(mousePos);
            StartCoroutine("SlowScale");
            _blockRepeatClick = true;
        }
        transform.position = transform.position + _moveToPoint * speed * Time.deltaTime;
    }

    IEnumerator SlowScale()
    {
        if (_blockRepeatClick !=true)
        {
            for (float q = 1f; q > 0.5f; q -= 0.01f * speed)
            {
                yield return new WaitForSeconds(0.03f);
                transform.localScale = new Vector3(q, q, q);
                if (_switch == true)
                {
                    _blockRepeatClick = false;
                    transform.localScale = _startLocalScaleForBall;
                    break;
                }
            }
        }
    }

    IEnumerator Ding()
    {
        _ding.SetActive(true);
        Text text = GameObject.Find("Ding").GetComponent<Text>();
        text.text = "+ " + tempScore.ToString();
        yield return new WaitForSeconds(0.5f);
        _ding.SetActive(false);
    }
}
