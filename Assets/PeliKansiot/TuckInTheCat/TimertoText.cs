using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimertoText : MonoBehaviour
{
    public Text text;
    public float timer = 8;
    private bool ticking = true;
    public int myInt;

    // Start is called before the first frame update
    void Start()
    {
        timer = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        myInt = (int)timer;

        if (ticking == true)
        {
            timer -= Time.deltaTime;
        }


        if (timer < 0)
        {
            //Debug.Log("oogabooga");
            ticking = false;
        }

        text.text = myInt.ToString();

    }
}
