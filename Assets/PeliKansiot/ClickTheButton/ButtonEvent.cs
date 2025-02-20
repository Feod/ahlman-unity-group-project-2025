using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private TextMeshPro teksikentta;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ButtonClicked()
    {
        teksikentta.text = "jee";
        print("Clicked");
        PelisceneLogiikka.instance.PeliPaattyi(true);
    }
}
