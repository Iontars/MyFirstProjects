using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Seven")
        {
            PlayerPrefs.SetInt("Seven", PlayerPrefs.GetInt("Seven") + 1);
        }
        if (collision.gameObject.tag == "Cherry")
        {
            PlayerPrefs.SetInt("Cherry", PlayerPrefs.GetInt("Cherry") + 1);
        }
        if (collision.gameObject.tag == "Grace")
        {
            PlayerPrefs.SetInt("Grace", PlayerPrefs.GetInt("Grace") + 1);
        }
        if (collision.gameObject.tag == "Lemon")
        {
            PlayerPrefs.SetInt("Lemon", PlayerPrefs.GetInt("Lemon") + 1);
        }
        if (collision.gameObject.tag == "Plum")
        {
            PlayerPrefs.SetInt("Plum", PlayerPrefs.GetInt("Plum") + 1);
        }
        if (collision.gameObject.tag == "Watermelon")
        {
            PlayerPrefs.SetInt("Watermelon", PlayerPrefs.GetInt("Watermelon") + 1);
        }
    }

}
