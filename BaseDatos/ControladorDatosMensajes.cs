using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ControladorDatosMensajes : MonoBehaviour
{
    /*
     * Guarda los mensajes mas importantes en un archivo
     */

    //Referencias a otros scripts
    llamarFunciones llamarfunciones;

    //Variables que usa a unity para el uso de funciones externas
    public string ArchivoDeGuardado_Mensajes;

    public DatosMensajes datosMensajes = new DatosMensajes();

    //variables de uso logico
    public string Debugs;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        ArchivoDeGuardado_Mensajes = Application.dataPath + "datos_mensajes.json";
    }

    private void Start()
    {
        //Referencias
        FuncReferencias();
    }
    private void Update()
    {
    }
    //------------------------------------------------------------------------------------------//
    //GUARDA LOS MENSAJES EN UN ARCHIVO---------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatos_Mensajes()
    {
        if(Debugs != datosMensajes.Mensaje25)
        //Remplaza cada mensaje con el anterior y permite la entrada de un nuevo mensaje
        datosMensajes = new DatosMensajes()
        {
            Mensaje1 = datosMensajes.Mensaje2,
            Mensaje2 = datosMensajes.Mensaje3,
            Mensaje3 = datosMensajes.Mensaje4,
            Mensaje4 = datosMensajes.Mensaje5,
            Mensaje5 = datosMensajes.Mensaje6,
            Mensaje6 = datosMensajes.Mensaje7,
            Mensaje7 = datosMensajes.Mensaje8,
            Mensaje8 = datosMensajes.Mensaje9,
            Mensaje9 = datosMensajes.Mensaje10,
            Mensaje10 = datosMensajes.Mensaje11,
            Mensaje11 = datosMensajes.Mensaje12,
            Mensaje12 = datosMensajes.Mensaje13,
            Mensaje13 = datosMensajes.Mensaje14,
            Mensaje14 = datosMensajes.Mensaje15,
            Mensaje15 = datosMensajes.Mensaje16,
            Mensaje16 = datosMensajes.Mensaje17,
            Mensaje17 = datosMensajes.Mensaje18,
            Mensaje18 = datosMensajes.Mensaje19,
            Mensaje19 = datosMensajes.Mensaje20,
            Mensaje20 = datosMensajes.Mensaje21,
            Mensaje21 = datosMensajes.Mensaje22,
            Mensaje22 = datosMensajes.Mensaje23,
            Mensaje23 = datosMensajes.Mensaje24,
            Mensaje24 = datosMensajes.Mensaje25,
            Mensaje25 = Debugs,

        };

        string cadenaJSON = JsonUtility.ToJson(datosMensajes);

        File.WriteAllText(ArchivoDeGuardado_Mensajes, cadenaJSON);

        Debug.Log("Los datos de los mensajes se han guardado exitosamente");
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncReferencias()
    {
        //Referencias
        llamarfunciones = FindObjectOfType<llamarFunciones>();
    }
}
