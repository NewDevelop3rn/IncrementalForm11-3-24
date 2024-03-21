using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    /*
     * Guarda el mensaje en el archivo de mensajes y luego cambia de escena
     */

    //Referencias a otros scripts
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Start()
    {
        //Referencias
        FuncReferencias();
    }
    //------------------------------------------------------------------------------------------//
    //CAMBIA DE ESCENA--------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncCambiarEscena(int Escena)
    {
        //Lo agrega a la lista de mensajes
        controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: FuncCambiarEscena()" + " Script: CambiarEscena" + " Debug.log: Se ha cambiado a la escena: " + Escena);

        llamarfunciones.llamarFuncControladorDatos(6);

        SceneManager.LoadScene(Escena);
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncReferencias()
    {
        //Referencias
        controladorDatosMensajes = (controladorDatosMensajes == null) ? controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>() : controladorDatosMensajes;
        llamarfunciones = (llamarfunciones == null) ? llamarfunciones = FindObjectOfType<llamarFunciones>() : llamarfunciones;
    }
}
