using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDatosMenu_Opciones : MonoBehaviour
{
    /*
     * Se guarda los datos del menu, para luego guardar el mensaje en el archivo de guardado de
     * "Mensajes", y se cargan los datos cuando sean llamados e igualmente guarda el mensaje en el
     * archivo de guardado de "Mensajes", si no existe el archivo, guarda el mensaje y carga de
     * nuevo la funcion de guardar datos.
     */

    //Referencias a otros scripts
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;

    //Variables que usa a unity para el uso de funciones externas
    public string ArchivoDeGuardado_MenuOpciones;

    public DatosMenu_Opciones datosMenu_Opciones = new DatosMenu_Opciones();

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        ArchivoDeGuardado_MenuOpciones = Application.dataPath + "DatosMenu_Opciones.json";
    }

    private void Start()
    {
        FuncReferencias();
    }
    private void Update()
    {
    }
    //------------------------------------------------------------------------------------------//
    //GUARDAR DATOS MENU OPCIONES---------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatos_MenuOpciones()
    {
        //Guarda los datos
        datosMenu_Opciones = new DatosMenu_Opciones()
        {      
            VolumenMenus_f = GameObject.FindWithTag("VolumenMenus").GetComponent<Slider>().value
        };

        string cadenaJSON = JsonUtility.ToJson(datosMenu_Opciones);

        File.WriteAllText(ArchivoDeGuardado_MenuOpciones, cadenaJSON);

        Debug.Log("Los datos del menu de opciones se han guardado exitosamente");

        //Guarda los mensajes en el archivo de mensajes
        FuncGuardarMensajes(1);
    }
    //------------------------------------------------------------------------------------------//
    //CARGAR DATOS MENU OPCIONES----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void CargarDatos_MenuOpciones()
    {
        if(File.Exists(ArchivoDeGuardado_MenuOpciones))
        {
            string contenidoJSON = File.ReadAllText(ArchivoDeGuardado_MenuOpciones);

            datosMenu_Opciones = JsonUtility.FromJson<DatosMenu_Opciones>(contenidoJSON);

            //Carga los datos del menu de opciones
            CargarDatos();

            Debug.Log("Los datos del menu de opciones se han cargado exitosamente");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(2);
        }
        else
        {
            Debug.Log("El archivo de menu de opciones no existe");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(3);

            //Guardara o creara un nuevo archivo
            GuardarDatos_MenuOpciones();
        }
    }
    public void CargarDatos()
    {
        //Carga el dato de volumen
        GameObject.FindWithTag("VolumenMenus").GetComponent<Slider>().value = datosMenu_Opciones.VolumenMenus_f;
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncGuardarMensajes(int Mensaje)
    {
        //Referencias
        FuncReferencias();

        if (Mensaje == 1)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: GuardarDatos_MenuOpciones()" + " Script: ControladorMenu_Opciones" + " Debug.log: Los datos del menu de inicio se han guardado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 2)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuOpciones()" + " Script: ControladorMenu_Opciones" + " Debug.log: Los datos del menu de opciones se han cargado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 3)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Error " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuOpciones()" + " Script: ControladorMenu_Opciones" + " Debug.log: El archivo de datos del menu de opciones no existe");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
    }
    public void FuncReferencias()
    {
        //Referencias
        controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
    }
}
