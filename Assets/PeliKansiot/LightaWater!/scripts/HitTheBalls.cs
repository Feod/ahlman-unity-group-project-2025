using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class HitTheBalls : MonoBehaviour
{
    public int SmackCount = 0;
    public GameObject Water;
    public GameObject Water_Place;
    public GameObject HIT;
    public TextMeshProUGUI SmackCounter;

    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("space has been pressed");
                BallsSmacked();
                
            }
            if (SmackCount == 10)
            { 
                
            }
            if (SmackCount == 50)
            {
                gameObject.GetComponent<Timelimit>().enabled = false;
                //StartCoroutine(WaitFunction());
                PelisceneLogiikka.instance.PeliPaattyi(true);
                Water.SetActive(true);
                Water_Place.SetActive(true);
                HIT.SetActive(false);
            }
        }
         
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(100f);
        Debug.Log("secunti kului");
    }

    public void BallsSmacked()
    {
        SmackCount++;

        SmackCounter.text = string.Format("{00} / 50", SmackCount);
    }
    
}
