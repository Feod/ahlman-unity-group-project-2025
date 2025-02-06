using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class HitTheBalls : MonoBehaviour
{
    public int SmackCount = 0;
    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("space has been pressed");
                BallsSmacked();
                
            }
            if (SmackCount == 50)
            {
                gameObject.GetComponent<Timelimit>().enabled = false;
                StartCoroutine(WaitFunction());
                PelisceneLogiikka.instance.PeliPaattyi(true);
                
            }
        }
         
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("secunti kului");
    }

    public void BallsSmacked()
    {
        SmackCount++;
    }
    
}
