using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiner : MonoBehaviour
{
    [SerializeField] private GameObject _spinerGO = null;

    private float speed = 0;
    public float Speed { get => speed; }

    public void Spin()
    {
        if (speed == 0)
        {
            PlayerPrefs.SetInt("Start_Spins", PlayerPrefs.GetInt("Start_Spins") - 1);
            StartCoroutine("SpinRotation");
        }
    }

    IEnumerator SpinRotation()
    {
        speed = Random.Range(3.0f, 7.0f);
        for (float i = speed; i >= 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            _spinerGO.transform.Rotate(0f, 0f, i);
        }
        speed = 0;
    }
}
