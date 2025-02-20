using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAddscript : MonoBehaviour
{
    public GameObject cat;
    public GameObject teddy;
    public GameObject blanket;
    public GameObject pillow;
    public GameObject ui;
    BoxCollider2D Collider;

    public AudioSource p;
    public AudioClip pillowdown;
    public AudioClip blanketdown;
    public AudioClip purr;

    

    SpriteRenderer spriteRenderer;
    public Sprite bed1, bed2, bed3, bed4, bed5;


    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        GetComponent<SpriteRenderer>().sprite = bed1;

        p = GetComponent<AudioSource>();

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "cat")
        {
            Debug.Log("cat is set");
            Destroy(cat);
            pillow.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = bed2;
        }

        if(collision.name == "pillow")
        {
            Destroy(pillow);
            GetComponent<SpriteRenderer>().sprite = bed3;
            blanket.SetActive(true);
            p.PlayOneShot(pillowdown, 1.5f);
        }

        if (collision.name == "blanket")
        {
            Debug.Log("blanket is set");
            Destroy(blanket);
            teddy.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = bed4;
            p.PlayOneShot(blanketdown);
        }

        if (collision.name == "teddy")
        {
            Destroy(teddy);
            Debug.Log("yippee");
            GetComponent<SpriteRenderer>().sprite = bed5;
            p.PlayOneShot(blanketdown);
            p.PlayOneShot(purr, 1.7f);
            ui.SetActive(false);
            PelisceneLogiikka.instance.PeliPaattyi(true);



        }

    }

}
