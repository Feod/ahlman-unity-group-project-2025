using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winbron : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PelisceneLogiikka.instance.PeliPaattyi(true);
    }





}
