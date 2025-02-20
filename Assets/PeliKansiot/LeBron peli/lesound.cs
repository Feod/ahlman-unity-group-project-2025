using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesound : MonoBehaviour
{
    public AudioSource leaudio;
    public AudioClip boing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        leaudio.PlayOneShot(boing);
    }




}
