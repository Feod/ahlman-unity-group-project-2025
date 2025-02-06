using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiJuomaxd : MonoBehaviour
{

    public SpriteRenderer canRenderer;
    public Sprite OGesko;
    public int JuomaID;


    private void Start()
    {
        canRenderer = GetComponent<SpriteRenderer>();
    }

    void ChangeSprite()
    {
        canRenderer.sprite = OGesko;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouseoveresko");

        //ChangeSprite();

        //PelisceneLogiikka.instance.PeliPaattyi(false);

        //Opiskelija.instance.Haavejuomarenderer.sprite

        // ==

        if (Opiskelija.instance.Haavejuomarenderer.sprite == canRenderer.sprite)
        {
            PelisceneLogiikka.instance.PeliPaattyi(true);
        }
    }


    
}
