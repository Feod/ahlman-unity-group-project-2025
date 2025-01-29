using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaEsimerkki : MonoBehaviour
{

    [SerializeField] private Rigidbody2D pelaajaRigidbody;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pelaajaRigidbody.AddForce(new Vector3(-100f, 0f, 0f));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pelaajaRigidbody.AddForce(new Vector3(100f, 0f, 0f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Oliko pallo pelaajan yl�puolella kun t�rm�ys tapahtui?
        if(collision.transform.position.y > this.transform.position.y)
        {
            //Pelaaja sai kopin.

            //Ilmoita pelin p��t�s, ja ett� pelaaja onnistui siin�.
            PelisceneLogiikka.instance.PeliPaattyi(true);
        }
    }
}
