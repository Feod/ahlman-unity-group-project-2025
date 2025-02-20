using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timelimit : MonoBehaviour
{
    public float TimeLeft;
    public bool timerOn = false;
    public TextMeshProUGUI TimerTxt;

    public void Start()
    {
        timerOn = true;
    }

    public void Update()
    {
        if (timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("time's up");
                TimeLeft = 0;
                timerOn = false;
                PelisceneLogiikka.instance.PeliPaattyi(false);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }  
}

