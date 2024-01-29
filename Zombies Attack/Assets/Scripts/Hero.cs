using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour // ���������� � SampleScene/Hierarchy/Hero
{
    [Header("Hero main parameters")]
    public float rateOfFire = 0.1f; // ����������������, ���������
    public float speedRotate = 200f; // �������� �������� �����
    [Space]
    public GameObject inputBullet; // ���� ������
    public GameObject spawnPoint; // ����� ������ ���� ������������� �����
    public GameObject BoomAnim; // ������ �������� ������
    GameObject currentBoomAnim; // �������� ������
    GameObject bullet; // ���������� ��� ��������� ����
    readonly float angleStopLeft = 220f; // ���������� ��� ���������� ���� �������� ����� �� ��� Z (����)
    readonly float angleStopRight = 140f; // ���������� ��� ���������� ���� �������� ����� �� ��� Z (�����)

    void Start()
    {
         Cursor.visible = false; // ������ ������
    }
    void Strike() // ����� ���������� �� ����� � ���������� ���� ����� 1.5 �������
    {
        Vector3 bulletPosition = spawnPoint.transform.position; // ������������ �������� ��������� ������ Instantiate ������ ����, ����������� �� ������� ������ ����
        bullet = Instantiate(inputBullet, bulletPosition, transform.rotation.normalized); // ������������� ������� ���� 
        Destroy(bullet, 2f); // �������������� ���� ����� 2 ���
    }
    void RotateHeroForPC() // ���������� ��� ������� ������
    {
        float mX = Input.GetAxis("Mouse X");
        float currentZ = GetComponent<Transform>().rotation.eulerAngles.z;
        if (currentZ > angleStopLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleStopLeft); // ������������ �������� ������ ������� �������
        }
        else if (currentZ < angleStopRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleStopRight); // ������������ �������� �� ������� �������
        }
        transform.Rotate(0, 0, -mX * speedRotate * Time.deltaTime, Space.World);

        // ������� ����������� ������� ����� Mathf.Clamp �� ����������, �������� �������� ��������������� ��������� � ������
        //float z = Mathf.Clamp(transform.rotation.z + Input.GetAxis("Mouse X") * speedRotate * Time.deltaTime, 220, 140);
        //transform.Rotate(0, 0, z)
    }
    void RotateHeroForMobile() // ���������� ��� �������
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // ������������ ������� ���� 
            Vector2 direction = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y); // ����� �� ������ ���� ��������
            transform.up = -direction; // �������, �������� ������������� �� �� ���������� ������
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombi")
        {
            Destroy(gameObject);
            Vector2 WhereToSpawn = new Vector2(transform.position.x, transform.position.y);
            currentBoomAnim = Instantiate(BoomAnim, WhereToSpawn, Quaternion.identity); // ����� �������� ������
            Destroy(currentBoomAnim, 3.5f);
        }
    }
    void Update()
    {
        RotateHeroForPC(); // ������ ���������� ��� �������
        RotateHeroForMobile(); // ������ ���������� ��� �������
        // ����������������
        if (!IsInvoking("Strike"))
        {
            Invoke("Strike", rateOfFire); // ��������� rateOfFire � �������
        }
    }
}
