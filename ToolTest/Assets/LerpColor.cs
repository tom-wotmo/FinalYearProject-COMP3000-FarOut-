using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LerpColor : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    

    public void AutumnColour()
    {
        myMaterial.color = Color.Lerp(Color.blue, Color.yellow, 1000f);
    }
}

