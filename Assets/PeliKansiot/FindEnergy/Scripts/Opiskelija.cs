using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opiskelija : MonoBehaviour
{
    public SpriteRenderer Haavejuomarenderer;
    public Sprite[] Haavejuomat;
    public int HaavejuomaID;

    public static Opiskelija instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        HaavejuomaID = Random.Range(0, Haavejuomat.Length);

        Haavejuomarenderer.sprite = Haavejuomat[HaavejuomaID];

    }

    
}
