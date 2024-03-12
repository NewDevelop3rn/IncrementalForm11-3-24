using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControladorDatosMenu_Inicio_RESPALDO : MonoBehaviour
{
    /*
     * Guarda los datos del archivo de guardado "actual", y guarda el mensaje en el archivo de
     * guardado de "mensajes", y carga los datos en caso de que el archivo de guardado "actual"
     * se pierda o se corrompa, y guarda el mensaje en el archivo de guardado de "mensajes".
     */

    //Referencia a otros scripts
    ControladorDatosMenu_Inicio controladorDatosMenu_Inicio;
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;

    //Variables que usa a unity para el uso de funciones externas
    public string ArchivoDeGuardado_MenuInicio_RESPALDO;
    public DatosMenu_Inicio_RESPALDO DatosMenu_Inicio_RESPALDO = new DatosMenu_Inicio_RESPALDO();

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        ArchivoDeGuardado_MenuInicio_RESPALDO = Application.dataPath + "DatosMenu_Inicio_RESPALDO.json";
    }

    private void Start()
    {
        //Referencias
        controladorDatosMenu_Inicio = (controladorDatosMenu_Inicio == null) ? controladorDatosMenu_Inicio = FindObjectOfType<ControladorDatosMenu_Inicio>() : controladorDatosMenu_Inicio;
        controladorDatosMensajes = (controladorDatosMensajes == null) ? controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>() : controladorDatosMensajes;
        llamarfunciones = (llamarfunciones == null) ? llamarfunciones = FindObjectOfType<llamarFunciones>() : llamarfunciones;
    }
    private void Update()
    {
        //Referencias
        controladorDatosMenu_Inicio = (controladorDatosMenu_Inicio == null) ? controladorDatosMenu_Inicio = FindObjectOfType<ControladorDatosMenu_Inicio>() : controladorDatosMenu_Inicio;
        controladorDatosMensajes = (controladorDatosMensajes == null) ? controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>() : controladorDatosMensajes;
        llamarfunciones = (llamarfunciones == null) ? llamarfunciones = FindObjectOfType<llamarFunciones>() : llamarfunciones;
    }
    //------------------------------------------------------------------------------------------//
    //GUARDAR DATOS MENU INICIO RESPALDO--------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatos_MenuInicio_RESPALDO()
    {
        //Guarda los datos
        DatosMenu_Inicio_RESPALDO = new DatosMenu_Inicio_RESPALDO()
        {
            ColorTitulo_f = controladorDatosMenu_Inicio.datosMenu_Inicio.ColorTitulo_f
        };

        string cadenaJSON = JsonUtility.ToJson(DatosMenu_Inicio_RESPALDO);

        File.WriteAllText(ArchivoDeGuardado_MenuInicio_RESPALDO, cadenaJSON);

        Debug.Log("Los datos del menu de inicio de RESPALDO se han guardado exitosamente");

        //llama a la funcion para que guarde los mensajes en el archivo de guardado de "mensajes"
        FuncGuardarMensajes(1);
    }
    //------------------------------------------------------------------------------------------//
    //CARGAR DATOS MENU INICIO RESPALDO---------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void CargarDatos_MenuInicio_RESPALDO()
    {
        if(File.Exists(ArchivoDeGuardado_MenuInicio_RESPALDO))
        {
            string contenidoJSON = File.ReadAllText(ArchivoDeGuardado_MenuInicio_RESPALDO);

            DatosMenu_Inicio_RESPALDO = JsonUtility.FromJson<DatosMenu_Inicio_RESPALDO>(contenidoJSON);

            //Se carga el color de los componentes del menu de inicio
            GameObject.Find("Play").GetComponent<CambioColorMenuInicio>().Color = DatosMenu_Inicio_RESPALDO.ColorTitulo_f;
            GameObject.Find("Options").GetComponent<CambioColorMenuInicio>().Color = DatosMenu_Inicio_RESPALDO.ColorTitulo_f;
            GameObject.Find("Exit").GetComponent<CambioColorMenuInicio>().Color = DatosMenu_Inicio_RESPALDO.ColorTitulo_f;
            GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color = DatosMenu_Inicio_RESPALDO.ColorTitulo_f;

            Debug.Log("Los datos del menu de inicio de RESPALDO se han cargado exitosamente");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(2);
        }
        else
        {
            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(3);

            Debug.LogWarning("El archivo de guardado de menu de inicio de RESPALDO ah sido ELIMINADO");
        }
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncGuardarMensajes(int Mensaje)
    {
        //Referencias
        controladorDatosMensajes = (controladorDatosMensajes == null) ? controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>() : controladorDatosMensajes;
        llamarfunciones = (llamarfunciones == null) ? llamarfunciones = FindObjectOfType<llamarFunciones>() : llamarfunciones;

        if (Mensaje == 1 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: GuardarDatos_MenuInicio_RESPALDO()" + " Script: ControladorMenu_Inicio_RESPALDO" + " Debug.log: Los datos del menu de inicio de RESPALDO se han guardado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 2 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuInicio_RESPALDO()" + " Script: ControladorMenu_Inicio_RESPALDO" + " Debug.log: Los datos del menu de inicio de RESPALDO se han cargado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 3 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Advertencia " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuInicio_RESPALDO()" + " Script: ControladorMenu_Inicio_RESPALDO" + " Debug.log: El archivo de datos del menu de inicio de RESPALDO ah sido ELIMINADO");
        }
    }
}
