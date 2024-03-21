using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    /*
     * Cuando es llamado sale del juego
     */

    //Referencias a otros scripts
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Start()
    {
        FuncReferencias();
    }
    //------------------------------------------------------------------------------------------//
    //SALE DEL JUEGO----------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void funcSalirJuego()
    {
        //Lo agrega a la lista de mensajes
        controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: FuncSalirJuego()" + " Script: SalirJuego" + " Debug.log: Hemos salido del juego");

        llamarfunciones.llamarFuncControladorDatos(6);

        Application.Quit();
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncReferencias()
    {
        //Referencias
        controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
    }
}
