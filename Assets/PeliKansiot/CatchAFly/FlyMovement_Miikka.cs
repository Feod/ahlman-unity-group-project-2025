using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement_Miikka : MonoBehaviour
{

    //Visual references:
    [SerializeField] private SpriteRenderer karpanenRenderer;
    [SerializeField] private Sprite kuolinFrame;

    [SerializeField] private AudioSource kuoliSound;

    [SerializeField] private Transform karpanen;
    private float aikaSeuraavaanHyppyyn;
    private bool karpanenElossa = true;

    void Update()
    {
        //Jos k‰rp‰nen ei ole en‰‰n elossa
        if (karpanenElossa == false)
            return; //Pys‰yt‰ funktio t‰h‰n.

        aikaSeuraavaanHyppyyn -= Time.deltaTime;
        if(aikaSeuraavaanHyppyyn < 0f)
        {
            HyppaaUuteenPositioon();
        }
    }

    void HyppaaUuteenPositioon()
    {
        aikaSeuraavaanHyppyyn = Random.Range(0.3f, 1f);

        //karpanen.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);

        Vector3 uusiPositio = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
        LeanTween.move(karpanen.gameObject, uusiPositio, 0.2f).setEase(LeanTweenType.easeInOutBack);

        Debug.Log("Hyppy tapahtui!");
    }

    public void KarpanenKuoli()
    {

        kuoliSound.Play();

        //Onko animaatio t‰ll‰ hetkell‰ p‰‰ll‰
        if (LeanTween.isTweening(karpanen.gameObject))
        {
            //Keskeyt‰ animaatio.
            LeanTween.cancel(karpanen.gameObject);
        }

        //Tallenna tietoa k‰rp‰sen elossa tilasta
        karpanenElossa = false;

        //Vaihda k‰rp‰sen frame
        karpanenRenderer.sprite = kuolinFrame;

        LeanTween.scale(karpanenRenderer.gameObject, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeOutExpo);

    }

    private void OnMouseDown()
    {
        KarpanenKuoli();

        PelisceneLogiikka.instance.PeliPaattyi(true);

    }



}
