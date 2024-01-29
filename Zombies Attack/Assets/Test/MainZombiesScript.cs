using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainZombiesScript : MonoBehaviour
{
    public GameObject target;
    public float speed = 2f;

    void Start()
    {

    }

    public void Move(float speed)
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            Destroy(collision.gameObject);
        }
    }


    void Update()
    {
        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        transform.Translate(directionToTarget * speed * Time.deltaTime);

    }
}