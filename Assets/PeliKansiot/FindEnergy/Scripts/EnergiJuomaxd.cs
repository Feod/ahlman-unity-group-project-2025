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
            Opiskelija.instance.MuutaOpiskelijanSprite(true);
            PelisceneLogiikka.instance.PeliPaattyi(true);
        }
        else
        {
            //V‰‰r‰ juoma. Tee opiskelijasta vihainen
            Opiskelija.instance.MuutaOpiskelijanSprite(false);
        }



    }


    
}
