using UnityEngine;

public class PisteetJaElamat : MonoBehaviour
{
    public static PisteetJaElamat instance;

    [HideInInspector] public int elamat;
    [HideInInspector] public int pisteet;
    [HideInInspector] public bool peliOnAlkanut;
    [HideInInspector] public bool onnistuikoPelaajaViimePelissa;

    //Äänet:
    [SerializeField] private AudioSource sound_Voitto;
    [SerializeField] private AudioSource sound_Havio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitGame()
    {
        Debug.Log("Game Initiated");
        elamat = 3;
        pisteet = 0;
    }


    public void IlmoitaPelattuPeliJaSenLopputulos(bool onnistuikoPelaaja)
    {

        if (onnistuikoPelaaja)
        {
            sound_Voitto.Play();
        }
        else
        {
            sound_Havio.Play();
        }

        onnistuikoPelaajaViimePelissa = onnistuikoPelaaja;
    }

    public void AddPoints(int amount)
    {
        pisteet += amount;
    }

    public void LoseLife()
    {
        elamat--;
    }
}