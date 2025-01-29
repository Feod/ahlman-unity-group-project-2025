using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PelisceneLogiikka : MonoBehaviour
{
    //Muuttujat:
    [SerializeField] private float pelinKestoSekunneissa;
    private bool peliCompleted;


    //public static instance, jotta muut scriptit voivat kutsua scripti‰
    public static PelisceneLogiikka instance;
    private void Awake()
    {

        instance = this;
    }

    private void Start()
    {
        //Ilmoita pelit virallisesti alkaneiksi.
        PisteetJaElamat.instance.peliOnAlkanut = true;

        //IEnumrator functiot tulee aina aloittaa StartCoroutinen() kautta.
        StartCoroutine(Ajastin());
    }

    //IEnumerator on funktio-tyyppi, jossa voi k‰ytt‰‰ odota-toimintoja.
    IEnumerator Ajastin()
    {
        //Odota pelinKestoSekunneissa
        yield return new WaitForSeconds(pelinKestoSekunneissa);

        //Ilmoita 
        PeliPaattyi(false);
    }



    public void PeliPaattyi(bool pelaajaOnnistuiTulos)
    {

        //Varmistus jottei peli loppuisi kahta kertaa saman matsin aikana.
        //Onko peli jo lopetettu?
        if (peliCompleted)
        {
            //Jos on, niin pyst‰yt‰ t‰m‰ funktio t‰h‰n.
            return; // (return lopettaa funktion heti)
        }

        //Tallenna muistiin ett‰ t‰m‰ peli on nyt ilmoitettu loppuneeksi.
        peliCompleted = true;

        //Tallenna pelin lopputulos
        PisteetJaElamat.instance.IlmoitaPelattuPeliJaSenLopputulos(pelaajaOnnistuiTulos);

        //K‰ynnist‰ MovePelaajaBackToMidScene funktio sekunnin kuluttua.
        Invoke("MovePelaajaBackToMidScene", 1f);
    }

    void MovePelaajaBackToMidScene()
    {
        //L‰het‰ pelaaja takaisin MidSceneen.
        SceneManager.LoadScene("MidScene");
    }

}
