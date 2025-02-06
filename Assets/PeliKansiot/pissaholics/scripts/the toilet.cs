using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thetoilet : MonoBehaviour
{

    public AudioSource hooray;

    private void Start()
    {
        hooray = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        //if mouse over shitter should display message
        Debug.Log("mouseovershitter");

        if(hooray.isPlaying == false)
            hooray.Play();

        PelisceneLogiikka.instance.PeliPaattyi(true);
    }

}
