using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catspritechange : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite cat1, cat2;
    public Dragscript d;
    public AudioSource s;
    public AudioClip pick;
    public AudioClip meow;
    //public AudioSource audioSource;
    private bool lifted = false;
    // Start is called before the first frame update
    void Start()
    {

        s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(d.dragging == true)
        {
            GetComponent<SpriteRenderer>().sprite = cat2;
            //Debug.Log("draggingcat");

            if (lifted == false)
            {
                s.PlayOneShot(meow, 0.1f);
                s.PlayOneShot(pick, 0.5f);
                lifted = true;
            }

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cat1;
            lifted = false;
        }




    }
}
