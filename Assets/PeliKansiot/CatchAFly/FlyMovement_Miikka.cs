using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement_Miikka : MonoBehaviour
{


    [SerializeField] private Transform karpanen;
    private float aikaSeuraavaanHyppyyn;

    void Update()
    {
        aikaSeuraavaanHyppyyn -= Time.deltaTime;
        if(aikaSeuraavaanHyppyyn < 0f)
        {
            HyppaaUuteenPositioon();
        }
    }

    void HyppaaUuteenPositioon()
    {
        aikaSeuraavaanHyppyyn = Random.Range(0.3f, 1f);

        //karpanen.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);

        Vector3 uusiPositio = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
        LeanTween.move(karpanen.gameObject, uusiPositio, 0.2f).setEase(LeanTweenType.easeInOutBack);

        Debug.Log("Hyppy tapahtui!");
    }


}
