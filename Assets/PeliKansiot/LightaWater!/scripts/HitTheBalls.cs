using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class HitTheBalls : MonoBehaviour
{
    public int SmackCount = 0;
    private void update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("space has been pressed");
                BallsSmacked();
            
            }
            if (SmackCount == 50)
            {
                PelisceneLogiikka.instance.PeliPaattyi(true);
                gameObject.GetComponent<Timelimit>().enabled = false;
            }
        }
         
    public void BallsSmacked()
    {
        SmackCount++;
    }
    
}
