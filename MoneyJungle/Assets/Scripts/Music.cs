using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip sound;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
