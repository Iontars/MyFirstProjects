using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private List<Transform> _segments = new List<Transform>();

    public Transform segmentPrefab;

    public int initialSize = 4;

    [SerializeField] private GameObject _canvGameover = null;
    [SerializeField] private Level_controller _currentTime = null;
    [SerializeField] private Text _GameOver = null;

    [SerializeField] private Vector2 direction;

    private void Start()
    {
        ResetState();
    }
    public void ControlTouch(string move)
    {
        if (direction == Vector2.left || direction == Vector2.right)
        {
            if (move == "up")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                if (direction.y == 0f && direction == Vector2.right)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                else if (direction.y == 0f && direction == Vector2.left)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                direction = Vector2.up;
            }

            else if (move == "down")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                if (direction.y == 0f && direction == Vector2.right)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                else if (direction.y == 0f && direction == Vector2.left)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                direction = Vector2.down;
            }


            /*if (directions == "up")
            {
                direction = Vector2.up;
            }
            else if (directions == "down")
            {
                direction = Vector2.down;
            }
        }
        else if (direction.y != 0.0f)
        {
            if (directions == "right")
            {
                direction = Vector2.right;
            }
            else if (directions == "left")
            {
                direction = Vector2.left;
            }*/
        }

        else if (direction == Vector2.up || direction == Vector2.down)
        {
            if (move == "right")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                if (direction.x == 0f && direction == Vector2.up)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                else if (direction.x == 0f && direction == Vector2.down)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                direction = Vector2.right;
            }


            if (move == "left")
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                if (direction.x == 0f && direction == Vector2.up)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                else if (direction.x == 0f && direction == Vector2.down)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                direction = Vector2.left;
            }
        }

    }
    private void Update()
    {
        SnakeControl();     
    }

    private void SnakeControl()
    {
        if (direction == Vector2.left || direction == Vector2.right)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                if (direction.y == 0f && direction == Vector2.right)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                else if (direction.y == 0f && direction == Vector2.left)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                direction = Vector2.up;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                if (direction.y == 0f && direction == Vector2.right)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                else if (direction.y == 0f && direction == Vector2.left)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                direction = Vector2.down;
            }
        }
        else if (direction == Vector2.up || direction == Vector2.down)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                if (direction.x == 0f && direction == Vector2.up)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                else if (direction.x == 0f && direction == Vector2.down)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                direction = Vector2.right;
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                if (direction.x == 0f && direction == Vector2.up)
                {
                    transform.Translate(0.5f, 0.5f, 0);
                }
                else if (direction.x == 0f && direction == Vector2.down)
                {
                    transform.Translate(0.5f, -0.5f, 0);
                }
                direction = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--) 
        {           
            _segments[i].rotation = _segments[i - 1].rotation;
            _segments[i].position = _segments[i - 1].position;
        }

        transform.Translate(1,0,0);
        //transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x, Mathf.Round(transform.position.y) + direction.y);
    }
    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        segment.rotation = _segments[_segments.Count - 1].rotation;
        _segments.Add(segment);
    }
    private void ResetState()
    {
        
        direction = Vector2.right;
        //transform.position = Vector3.zero;

        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        //

        _segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++) {
            Grow();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {            
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            _GameOver.text = _currentTime.CurrentTime.ToString();
            Time.timeScale = 0;
            _canvGameover.SetActive(true);
            PlayerPrefs.DeleteKey("TotalCost");
            ResetState();
        }
    }

}
