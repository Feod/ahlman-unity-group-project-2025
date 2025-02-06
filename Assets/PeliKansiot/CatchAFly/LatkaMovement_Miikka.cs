using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatkaMovement_Miikka : MonoBehaviour
{

    [SerializeField] private AudioSource latkaHitSound;

    [SerializeField] private Transform latkaRoot;

    [SerializeField] private Transform latkaKuva;
    [SerializeField] private Transform latkaVarjo;

    private bool latkaHitAnimating;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set the Z position to 0 if you're working in a 2D space (otherwise, adjust accordingly)

        latkaRoot.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            //Tee LatkaHit(), vain jos edellinen animaatio ei ole p‰‰ll‰
            if(latkaHitAnimating == false)
                StartCoroutine(LatkaHit());
            
        }

    }

    IEnumerator LatkaHit()
    {
        latkaHitAnimating = true;

        //Soita ‰‰ni:
        latkaHitSound.Play();

        //Tallenna varjon positio ja l‰tk‰n 
        Vector3 latkaAlkuperainenPositio = latkaKuva.localPosition;
        Vector3 varjoPositio = latkaVarjo.localPosition;

        //K‰yt‰ kuitenkin alkuper‰isen position Z-arvoa
        varjoPositio.z = latkaAlkuperainenPositio.z;

        latkaKuva.localPosition = varjoPositio;

        yield return new WaitForSeconds(0.1f);

        latkaKuva.localPosition = latkaAlkuperainenPositio;

        latkaHitAnimating = false;

    }
}
