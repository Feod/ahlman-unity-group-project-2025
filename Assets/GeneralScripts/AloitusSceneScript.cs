using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AloitusSceneScript : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            AloitaPeli();
        }
    }

    void AloitaPeli()
    {
        SceneManager.LoadScene("MidScene");
    }

}
