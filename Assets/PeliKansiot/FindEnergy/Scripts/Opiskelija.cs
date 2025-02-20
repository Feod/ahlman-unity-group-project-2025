using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opiskelija : MonoBehaviour
{

    //Opiskelija
    public SpriteRenderer opiskelijaRenderer;
    public Sprite spriteIloinenOpiskelija;
    public Sprite spriteSurullinenOpiskelija;


    //----

    public SpriteRenderer Haavejuomarenderer;
    public Sprite[] Haavejuomat;
    public int HaavejuomaID;

    public static Opiskelija instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        HaavejuomaID = Random.Range(0, Haavejuomat.Length);

        Haavejuomarenderer.sprite = Haavejuomat[HaavejuomaID];

    }

    public void MuutaOpiskelijanSprite(bool iloinen)
    {

        if(iloinen == true)
        {
            opiskelijaRenderer.sprite = spriteIloinenOpiskelija;
        }
        else
        {
            opiskelijaRenderer.sprite = spriteSurullinenOpiskelija;
        }

    }


    
}
