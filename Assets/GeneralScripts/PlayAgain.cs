using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    
    public void LataaAloitusScene()
    {
        SceneManager.LoadScene(0);
    }

}
