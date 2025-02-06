using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine.UI;
using UnityEngine;

public class arms : MonoBehaviour
{
    public GameObject NORMAL;
    public GameObject HIT;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            NORMAL.SetActive(false);
            HIT.SetActive(true);
        }
        else 
        {
            NORMAL.SetActive(true);
            HIT.SetActive(false);
        }
    }
}
