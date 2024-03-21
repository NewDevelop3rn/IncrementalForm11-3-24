using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarTransicion : MonoBehaviour
{
    //Referencias a otros scripts
    CambiarEscena cambiarEscena;
    llamarFunciones llamarfunciones;
    AnimTitulo animTitulo;
    AnimPantallasNegras animPantallasNegras;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void Start()
    {
        //Referencias
        FuncReferencias();
    }
    //------------------------------------------------------------------------------------------//
    //ACTIVA ANIMACION Y HACE EL CAMBIO DE ESCENA-----------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncActivarTransicion(int Escena)
    {
        //Se llama a la funcion para hacer la animas
        StartCoroutine(llamarAnimacionesTitulo());

        //Se llama a la funcion para cambiar de escena
        StartCoroutine(llamarFuncionCambiarEscena(Escena));
    }
    IEnumerator llamarAnimacionesTitulo()
    {
        animPantallasNegras.MoverPantalla1HaciaElCentroSalida();
        animPantallasNegras.MoverPantalla2HaciaElCentroSalida();
        yield return new WaitForSeconds(.5f);
        //Se activa la animacion de salida 
        animTitulo.MoverElTituloHaciaAbajo();
    }
    IEnumerator llamarFuncionCambiarEscena(int Escena)
    {
        yield return new WaitForSeconds(1.5f);

        //Guarda los datos de los controladores
        GuardarDatosAntesCambioEscena();

        //Manda mensaje
        MensajeAntesDeCambiarEscena(Escena);

        //Cambiar escena
        cambiarEscena.FuncCambiarEscena(Escena);

    }
    //------------------------------------------------------------------------------------------//
    //GUARDA LOS DATOS DE LOS CONTROLADORES-----------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatosAntesCambioEscena()
    {
        //Guarda los datos dependiendo de la escena en la que se encuentre 
        if (GameObject.Find("Menu_Inicial"))
        {
            llamarfunciones.llamarFuncControladorDatos(0);
        }
        else if (GameObject.Find("Menu_Partidas"))
        {
            llamarfunciones.llamarFuncControladorDatos(2);
        }
        else if (GameObject.Find("Menu_Opciones"))
        {
            llamarfunciones.llamarFuncControladorDatos(4);
        }
    }

    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncReferencias()
    {
        //Referencias
        cambiarEscena = FindObjectOfType<CambiarEscena>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
        animTitulo = FindObjectOfType<AnimTitulo>();
        animPantallasNegras = FindObjectOfType<AnimPantallasNegras>();
    }
    public void MensajeAntesDeCambiarEscena(int Escena)
    {
        if (Escena == 1)
        {
            Debug.Log("Se ah cambiado al menu de partidas");
        }
        else if (Escena == 2)
        {
            Debug.Log("Se ah cambiado al menu de opciones");
        }
        else if (Escena == 0)
        {
            Debug.Log("Se ah cambiado al menu de inicio");
        }
    }
}
