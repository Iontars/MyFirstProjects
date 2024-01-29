using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "10000")
        {
            PlayerPrefs.SetInt("Spin_Score", 10000);
            PlayerPrefs.SetInt("Spin_Count", 0);
        }
        else if (other.gameObject.tag == "12000")
        {
            PlayerPrefs.SetInt("Spin_Score", 12000);
            PlayerPrefs.SetInt("Spin_Count", 0);
        }
        else if (other.gameObject.tag == "15000")
        {
            PlayerPrefs.SetInt("Spin_Score", 15000);
            PlayerPrefs.SetInt("Spin_Count", 0);
        }
        else if (other.gameObject.tag == "30000")
        {
            PlayerPrefs.SetInt("Spin_Score", 30000);
            PlayerPrefs.SetInt("Spin_Count", 0);
        }
        else if (other.gameObject.tag == "1_spin")
        {
            PlayerPrefs.SetInt("Spin_Count", 1 );
            PlayerPrefs.SetInt("Spin_Score", 0);
        }
        else if (other.gameObject.tag == "3_spin")
        {
            PlayerPrefs.SetInt("Spin_Count", 3);
            PlayerPrefs.SetInt("Spin_Score", 0);

        }
        else if (other.gameObject.tag == "Zero")
        {
            PlayerPrefs.SetInt("Spin_Score", 0);
            PlayerPrefs.SetInt("Spin_Count", 0);
        }
    }
}
