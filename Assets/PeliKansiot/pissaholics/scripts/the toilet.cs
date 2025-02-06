using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thetoilet : MonoBehaviour
{

    public AudioSource hooray;

    public GameObject pacifists;
    public GameObject neutrals;
    public GameObject genocides;
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

        pacifists.SetActive(true);
        neutrals.SetActive(false);
        genocides.SetActive(false);

        PelisceneLogiikka.instance.PeliPaattyi(true);
    }

}
