using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class arms : MonoBehaviour
{
    public GameObject NORMAL;
    public GameObject HIT;
    public AudioSource[] SoundFX;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SoundFX[0].Play();
            NORMAL.SetActive(false);
            HIT.SetActive(true);
        }
        else 
        {
            NORMAL.SetActive(true);
            HIT.SetActive(false);
        }
    }
}
