using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MidSceneLogic : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI otsikkoLabel;


    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI livesLabel;

    void Start()
    {
        UpdateLabels();
        StartCoroutine(MidSceneAnimaatio());
    }

    IEnumerator MidSceneAnimaatio()
    {
        //Odota 1f sekunttia
        yield return new WaitForSeconds(1f);

        //Onko peli jo alkanut?
        if (PisteetJaElamat.instance.peliOnAlkanut)
        {
            //Onnistuiko pelaaja edellisell‰ kierroksella?
            if (PisteetJaElamat.instance.onnistuikoPelaajaViimePelissa)
            {
                PisteetJaElamat.instance.AddPoints(1);
            }
            else
            {
                PisteetJaElamat.instance.LoseLife();
            }
            UpdateLabels();
        }

        //Odota 2f sekunttia
        yield return new WaitForSeconds(2f);

        //Onko pelaajalla viel‰ el‰mi‰ jatkaa peli‰?
        if(PisteetJaElamat.instance.elamat > 0)
        {
            LataaSeuraavaPeliscene();
        }
        else
        {
            otsikkoLabel.text = "Peli p‰‰ttyi.";
        }
    }


    void UpdateLabels()
    {
        scoreLabel.text = "Score: " + PisteetJaElamat.instance.pisteet;
        livesLabel.text = "Lives: " + PisteetJaElamat.instance.elamat;
    }

    void LataaSeuraavaPeliscene()
    {
        //Tallenna satunnainen numer 2 (ensimm‰isen peliscenen numero) ja scenejen koko lukum‰‰r‰n v‰lilt‰.
        int satunnainenScene = Random.Range(2, SceneManager.sceneCount);

        //Siirry t‰h‰n satunnaiseen sceneen
        SceneManager.LoadScene(satunnainenScene);
        
    }

}
