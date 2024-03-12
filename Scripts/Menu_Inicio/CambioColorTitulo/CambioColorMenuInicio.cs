using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CambioColorMenuInicio : MonoBehaviour
{
    [SerializeField] Image imagen;
    [SerializeField] public float Color;
    [SerializeField] float VelocidadCambioColor;
    void Update()
    {
        CambiarColor(); 
    }
    public void CambiarColor()
    {
        if (imagen != null) {
            imagen.color = UnityEngine.Color.HSVToRGB(Color / 360, 100 / 100, 100 / 100);
            Color += VelocidadCambioColor;
            Color = (Color >= 360) ? Color = 0 : Color;
        }
    }
}
