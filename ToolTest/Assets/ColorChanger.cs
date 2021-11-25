using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material myMaterial;

    public void AutumnColour()
    {
        myMaterial.color = Color.Lerp(Color.blue, Color.red, 5f);
    }
}
