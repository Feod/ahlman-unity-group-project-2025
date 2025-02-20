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

        //A
        LeanTween.scale(opiskelijaRenderer.gameObject, opiskelijaRenderer.transform.localScale * 1.05f, 0.4f).setEase(LeanTweenType.punch);

        if(iloinen == true)
        {
            //B

            opiskelijaRenderer.sprite = spriteIloinenOpiskelija;
        }
        else
        {
            //C
            LeanTween.scale(Haavejuomarenderer.gameObject, Haavejuomarenderer.transform.localScale * 1.5f, 0.6f).setEase(LeanTweenType.punch);
            LeanTween.rotateZ(Haavejuomarenderer.gameObject, Random.Range(-90f,90),1f).setEase(LeanTweenType.punch);

            opiskelijaRenderer.sprite = spriteSurullinenOpiskelija;
        }
        //D
    }

    



    
}
