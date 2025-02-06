using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teddysound : MonoBehaviour
{
    public Dragscript d;
    public AudioSource audioSource;

    private bool lifted = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (d.dragging == true)
        {

            //Debug.Log("draggingcat");

            if (lifted == false)
            {

                audioSource.Play();
                lifted = true;
            }
        }
        else
        {

            lifted = false;
        }
    }
}
