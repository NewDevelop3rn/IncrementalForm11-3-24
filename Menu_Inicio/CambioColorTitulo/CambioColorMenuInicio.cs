using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CambioColorMenuInicio : MonoBehaviour
{
    /*
     * Cambia cada frame el color del titulo y otros objetos del UI, y se regresa cuando llega al 
     * "limite"
     */

    //Variables que usa a unity para el uso de funciones externas
    [SerializeField] Image imagen;

    //variables de uso logico
    [SerializeField] public float Color;
    [SerializeField] float VelocidadCambioColor;
    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    void Update()
    {
        CambiarColor(); 
    }
    //------------------------------------------------------------------------------------------//
    //FUNCION CAMBIAR COLOR TITULO--------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void CambiarColor()
    {
        if (imagen != null) {
            imagen.color = UnityEngine.Color.HSVToRGB(Color / 360, 100 / 100, 100 / 100);
            Color += VelocidadCambioColor;
            Color = (Color >= 360) ? Color = 0 : Color;
        }
    }
}
