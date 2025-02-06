using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blanketsound : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public Sprite blnk1, blnk2;
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
            GetComponent<SpriteRenderer>().sprite = blnk2;
            if (lifted == false)
            {

                audioSource.Play();
                lifted = true;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = blnk1;
            lifted = false;
        }
    }
}
