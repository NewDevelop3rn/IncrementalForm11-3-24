using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ActivarTransicion : MonoBehaviour
{
    CambiarEscena cambiarEscena;
    llamarFunciones llamarfunciones;
    AnimTitulo animTitulo;
    AnimPantallasNegras animPantallasNegras;

    [SerializeField] Animator animatorPantalla1;
    [SerializeField] Animator animatorPantalla2;
    [SerializeField] Animator animatorTitulo;

    public void Start()
    {
        //Se hace referencia al script
        cambiarEscena = FindObjectOfType<CambiarEscena>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
        animTitulo = FindObjectOfType<AnimTitulo>();
        animPantallasNegras = FindObjectOfType<AnimPantallasNegras>();
    }
    public void FuncActivarTransicion(int Escena)
    {
        //Se llama a una funcion
        StartCoroutine(llamarAnimacionesTitulo());

        //Se llama a una funcion
        StartCoroutine(llamarFuncionCambiarEscena(Escena));
    }
    IEnumerator llamarAnimacionesTitulo()
    {
        //animPantallasNegras.MoverPantalla1AlCentro();
        //animPantallasNegras.MoverPantalla2AlCentro();
        yield return new WaitForSeconds(.5f);
        //Se activa la animacion de salida 
        //animTitulo.MoverTituloHaciaAbajo();
    }
    IEnumerator llamarFuncionCambiarEscena(int Escena)
    {
        yield return new WaitForSeconds(1.5f);
        //GuardarDatos
        llamarfunciones.llamarFuncControladorDatos(0);

        //Cambiar escena
        cambiarEscena.FuncCambiarEscena(Escena);
        if(Escena == 1)
        {
            Debug.Log("Se ah cambiado al menu de partidas");
        }else if(Escena == 2)
        {
            Debug.Log("Se ah cambiado al menu de opciones");
        }
    }
}
