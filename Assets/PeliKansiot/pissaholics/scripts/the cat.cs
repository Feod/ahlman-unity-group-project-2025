using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thecat : MonoBehaviour
{

    public AudioSource why;

    public SpriteRenderer catRenderer;
    public Sprite soggycat;

    private void Start()
    {
        why = GetComponent<AudioSource>();
        catRenderer = GetComponent<SpriteRenderer>();
    }
    
    void ChangeSprite()
    {
        catRenderer.sprite = soggycat;
    }
    
    private void OnMouseOver()
    {
        //if mouse over shitter should display message
        Debug.Log("mouseovercat");

        if (why.isPlaying == false)
            why.Play();

        ChangeSprite();

        PelisceneLogiikka.instance.PeliPaattyi(false);
    }

}
