using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
//using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDatosMenu_Partidas : MonoBehaviour
{
    /*
     * Guarda el nombre de las partidas, la duracion de cada una de estas y el color del titulo
     * y carga los datos cuando se le es indicado aparte de guardar los mensajes en un archivo de
     * guardado de mensajes
     */

    //Referencias a otros scripts
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;
    DatosDeScriptsParaBaseDatos DatosDeScriptsParaBaseDatos;
    ControladorDatosMenu_Inicio ControladorDatosMenu_Inicio;

    //Variables que usa a unity para el uso de funciones externas
    public string ArchivoDeGuardado_MenuPartidas;

    public DatosMenu_Partidas datosMenu_Partidas = new DatosMenu_Partidas();

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        ArchivoDeGuardado_MenuPartidas = Application.dataPath + "datos_MenuPartidas.json";
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
    //GUARDAR DATOS MENU INICIO-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatos_MenuPartidas()
    {
        datosMenu_Partidas = new DatosMenu_Partidas()
        {
            //Se guardan los nombres de las partidas
            NombrePartida1_s = GameObject.FindWithTag("NombrePartida1").GetComponent<TMP_InputField>().text,
            NombrePartida2_s = GameObject.FindWithTag("NombrePartida2").GetComponent<TMP_InputField>().text,
            NombrePartida3_s = GameObject.FindWithTag("NombrePartida3").GetComponent<TMP_InputField>().text,

            //Se guardan el tiempo de las partidas
            DiasPartida1_i = GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().DiasPartida1,
            HorasPartida1_i = GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().HorasPartida1,
            MinutosPartida1_i = GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().MinutosPartida1,
            DiasPartida2_i = GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().DiasPartida2,
            HorasPartida2_i = GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().HorasPartida2,
            MinutosPartida2_i = GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().MinutosPartida2,
            DiasPartida3_i = GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().DiasPartida3,
            HorasPartida3_i = GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().HorasPartida3,
            MinutosPartida3_i = GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().MinutosPartida3,

            //Se guarda el color del titulo
            ColorTitulo_f = GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color
        };

        string cadenaJSON = JsonUtility.ToJson(datosMenu_Partidas);

        File.WriteAllText(ArchivoDeGuardado_MenuPartidas, cadenaJSON);

        Debug.Log("Los datos del menu de partidas se han guardado exitosamente");

        //Guarda los mensajes en el archivo de mensajes
        FuncGuardarMensajes(3);

        //Guardar los nuevos mensajes en el archivo de texto
        llamarfunciones.llamarFuncControladorDatos(6);
    }
    public void CargarDatos_MenuPartidas()
    {
        if (File.Exists(ArchivoDeGuardado_MenuPartidas))
        {
            string contenidoJSON = File.ReadAllText(ArchivoDeGuardado_MenuPartidas);

            datosMenu_Partidas = JsonUtility.FromJson<DatosMenu_Partidas>(contenidoJSON);

            //Carga los datos del menu de partidas
            CargarDatos();

            Debug.Log("Los datos del menu de partidas se han cargado exitosamente");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(2);

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else
        {
            Debug.Log("El archivo de menu de partidas no existe");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(3);

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);

            //Guardara o creara un nuevo archivo
            GuardarDatos_MenuPartidas();
        }
    }
    public void CargarDatos()
    {
        //Se cargan los nombres de las partidas
        GameObject.FindWithTag("NombrePartida1").GetComponent<TMP_InputField>().text = datosMenu_Partidas.NombrePartida1_s;
        GameObject.FindWithTag("NombrePartida2").GetComponent<TMP_InputField>().text = datosMenu_Partidas.NombrePartida2_s;
        GameObject.FindWithTag("NombrePartida3").GetComponent<TMP_InputField>().text = datosMenu_Partidas.NombrePartida3_s;

        //Se cargan el tiempo de las partidas
        GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().DiasPartida1 = datosMenu_Partidas.DiasPartida1_i;
        GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().HorasPartida1 = datosMenu_Partidas.HorasPartida1_i;
        GameObject.FindWithTag("Partida1").GetComponent<ContadorTiempoPartidas>().MinutosPartida1 = datosMenu_Partidas.MinutosPartida1_i;
        GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().DiasPartida2 = datosMenu_Partidas.DiasPartida2_i;
        GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().HorasPartida2 = datosMenu_Partidas.HorasPartida2_i;
        GameObject.FindWithTag("Partida2").GetComponent<ContadorTiempoPartidas>().MinutosPartida2 = datosMenu_Partidas.MinutosPartida2_i;
        GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().DiasPartida3 = datosMenu_Partidas.DiasPartida3_i;
        GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().HorasPartida3 = datosMenu_Partidas.HorasPartida3_i;
        GameObject.FindWithTag("Partida3").GetComponent<ContadorTiempoPartidas>().MinutosPartida3 = datosMenu_Partidas.MinutosPartida3_i;

        //Carga el color del titulo-Cambiar el codigo como en el controlador del inicio
        GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color = GameObject.Find("BaseDatos").GetComponent<ControladorDatosMenu_Inicio>().datosMenu_Inicio.ColorTitulo_f;
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncGuardarMensajes(int Mensaje)
    {
        //Referencias
        FuncReferencias();

        if (Mensaje == 1 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: GuardarDatos_MenuInicio()" + " Script: ControladorMenu_Inicio" + " Debug.log: Los datos del menu de inicio se han guardado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 2 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuInicio()" + " Script: ControladorMenu_Inicio" + " Debug.log: Los datos del menu de inicio se han cargado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
        else if (Mensaje == 3 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Error " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuInicio()" + " Script: ControladorMenu_Inicio" + " Debug.log: El archivo de datos del menu de inicio no existe");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }
    }
    public void FuncReferencias()
    {
        //Referencias
        controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>();
        DatosDeScriptsParaBaseDatos = FindObjectOfType<DatosDeScriptsParaBaseDatos>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
        ControladorDatosMenu_Inicio = FindObjectOfType<ControladorDatosMenu_Inicio>();
    }
}
