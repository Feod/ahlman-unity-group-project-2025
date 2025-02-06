using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MidSceneLogic : MonoBehaviour
{

    //UI Referenssit:
    [SerializeField] private TextMeshProUGUI otsikkoLabel;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI livesLabel;

    [SerializeField] private GameObject playAgainButton;

    void Start()
    {
        playAgainButton.SetActive(false);
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

                //Animoi scorelabel
                LeanTween.scale(scoreLabel.gameObject, Vector3.one * 3f, 0.6f).setEase(LeanTweenType.punch);

            }
            else
            {
                PisteetJaElamat.instance.LoseLife();

                //Animoi livesLabel
                LeanTween.scale(livesLabel.gameObject, Vector3.one * 3f, 0.6f).setEase(LeanTweenType.punch);

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
            //Peli p‰‰ttyi
            otsikkoLabel.text = "Peli p‰‰ttyi.";

            //Korosta pisteet
            LeanTween.scale(scoreLabel.gameObject, Vector3.one * 1.5f, 0.4f).setEase(LeanTweenType.easeOutBack);

            //Odota sekuntti
            yield return new WaitForSeconds(1f);

            //Paljasta play again button
            playAgainButton.SetActive(true);
            LeanTween.scale(playAgainButton, Vector3.one * 1.2f, 0.5f).setEase(LeanTweenType.punch);

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
        int satunnainenScene = Random.Range(2, SceneManager.sceneCountInBuildSettings);

        //Siirry t‰h‰n satunnaiseen sceneen
        SceneManager.LoadScene(satunnainenScene);
        
    }

    

}
