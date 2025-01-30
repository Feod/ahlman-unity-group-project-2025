using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class HitTheBalls : MonoBehaviour
{
    public int SmackCount = 0;
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("space has been pressed");
                BallsSmacked();
            
            }
            if (SmackCount == 50)
            {
                PelisceneLogiikka.instance.PeliPaattyi(true);
            }
        }
         
    public void BallsSmacked()
    {
        SmackCount++;
    }
    
}
