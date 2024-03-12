using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControladorDatosMenu_Inicio : MonoBehaviour
{
    /*
     * Al momento de guardar, el archivo de respaldo actualiza sus datos con el actual, para luego
     * este actualizarse con los datos en tiempo real y guardar el mensaje en el archivo. Al mome-
     * nto de cargar los datos verifica que exista el archivo y no este corrompido, si esta,
     * corrompido carga los datos del archivo de "respaldo", si no esta corrompido carga los datos 
     * del archivo de guardado "actual", e igualmente si no existe el archivo "actual" carga los 
     * datos del archivo de guardado de "respaldo" y guarda el mensaje en el archivo de guardado
     * de "mensajes".
     */

    //Referencias a otros scripts
    DatosDeScriptsParaBaseDatos DatosDeScriptsParaBaseDatos;
    CambioColorMenuInicio cambioColorMenuInicio;
    ControladorDatosMensajes controladorDatosMensajes;
    public llamarFunciones llamarfunciones;
    ControladorDatosMenu_Inicio_RESPALDO ControladorDatosMenu_Inicio_RESPALDO;

    //Variables que usa a unity para el uso de funciones externas
    public string ArchivoDeGuardado_MenuInicio;

    public  DatosMenu_Inicio datosMenu_Inicio = new DatosMenu_Inicio();

    //variables de uso logico
    private bool DatosOrganizadosArchivoRespaldo = true;
    private bool EntrarJuego = true;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        ArchivoDeGuardado_MenuInicio = Application.dataPath + "datos_MenuInicio.json";
    }

    private void Start()
    {
        FuncReferencias();
    }

    private void Update()
    {
    }
    //------------------------------------------------------------------------------------------//
    //GUARDAR DATOS MENU INICIO-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void GuardarDatosMenu_Inicio()
    {
        //llama a la funcion para actualizar los datos del archivo de respaldo
        GuardarArchivoRespaldo();

        //Guarda los datos
        datosMenu_Inicio = new DatosMenu_Inicio()
        {
            ColorTitulo_f = GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color
        };

        string cadenaJSON = JsonUtility.ToJson(datosMenu_Inicio);

        File.WriteAllText(ArchivoDeGuardado_MenuInicio, cadenaJSON);

        Debug.Log("Los datos del menu de inicio se han guardado exitosamente");

        //Hace funciones extra para que todo funcione bien
        Otros();
    }
    public void GuardarArchivoRespaldo()
    {
        //Actualiza el archivo de respaldo
        if (DatosOrganizadosArchivoRespaldo == true)
        {
            ControladorDatosMenu_Inicio_RESPALDO.GuardarDatos_MenuInicio_RESPALDO();
        }
    }
    public void Otros()
    {
        //Guarda los mensajes en el archivo de mensajes
        FuncGuardarMensajes(1);

        //La variable cambia a true para que el archivo de respaldo se actualize despues del uso de este
        DatosOrganizadosArchivoRespaldo = true;
    }

    //------------------------------------------------------------------------------------------//
    //CARGAR DATOS MENU INICIO------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//

    public void CargarDatos_MenuInicio()
    {
        if(File.Exists(ArchivoDeGuardado_MenuInicio))
        {
            //Verifica que el contenido del archivo de guardado sea el correcto, si no, carga los
            //datos del archivo de respaldo
            VerificadorDeArchivoCorrompido();

            //Se carga el color de los componentes del menu de inicio
            GameObject.Find("Play").GetComponent<CambioColorMenuInicio>().Color = datosMenu_Inicio.ColorTitulo_f;
            GameObject.Find("Options").GetComponent<CambioColorMenuInicio>().Color = datosMenu_Inicio.ColorTitulo_f;
            GameObject.Find("Exit").GetComponent<CambioColorMenuInicio>().Color = datosMenu_Inicio.ColorTitulo_f;
            if(EntrarJuego == true)
            {
                GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color = datosMenu_Inicio.ColorTitulo_f;
                EntrarJuego = false;
                Debug.Log("Estado de la variable EntrarJuego: " + EntrarJuego + ", Hemos entrado al juego");
            }
            else
            {
                GameObject.Find("IncrementalForms-Titulo").GetComponent<CambioColorMenuInicio>().Color = GameObject.Find("BaseDatos").GetComponent<ControladorDatosMenu_Partidas>().datosMenu_Partidas.ColorTitulo_f;
                GameObject.Find("Play").GetComponent<CambioColorMenuInicio>().Color = GameObject.Find("BaseDatos").GetComponent<ControladorDatosMenu_Partidas>().datosMenu_Partidas.ColorTitulo_f;
                GameObject.Find("Options").GetComponent<CambioColorMenuInicio>().Color = GameObject.Find("BaseDatos").GetComponent<ControladorDatosMenu_Partidas>().datosMenu_Partidas.ColorTitulo_f;
                GameObject.Find("Exit").GetComponent<CambioColorMenuInicio>().Color = GameObject.Find("BaseDatos").GetComponent<ControladorDatosMenu_Partidas>().datosMenu_Partidas.ColorTitulo_f;
            }

            Debug.Log("Los datos del menu de inicio se han cargado exitosamente");

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(2);
        }
        else
        {
            Debug.LogWarning("El archivo de datos de menu de inicio no existe");

            //Cambia la variable a false, para evitar que se guarden mal los datos del archivo de respaldo
            DatosOrganizadosArchivoRespaldo = false;

            //Guarda los mensajes en el archivo de mensajes
            FuncGuardarMensajes(3);

            //Crea un nuevo archivo
            CrearUnArchivoDeGuardadoNuevo();

            //llama a la funcion de cargar datos del archivo de respaldo
            ControladorDatosMenu_Inicio_RESPALDO.CargarDatos_MenuInicio_RESPALDO();
        }
    }
    public void VerificadorDeArchivoCorrompido()
    {
        string contenidoJSON = File.ReadAllText(ArchivoDeGuardado_MenuInicio);

        if (contenidoJSON.Contains("ColorTitulo_f"))
        {
            //Todo esta bien
        }
        else
        {
            Debug.Log("Se ah activado el archivo de datos de Menu_Inicio de Respaldo");

            //Cambia la variable a false, para evitar que se guarden mal los datos del archivo de respaldo
            DatosOrganizadosArchivoRespaldo = false;

            //llamar a la funcion de cargar datos en el archivo de respaldo
            ControladorDatosMenu_Inicio_RESPALDO.CargarDatos_MenuInicio_RESPALDO();
        }

        datosMenu_Inicio = JsonUtility.FromJson<DatosMenu_Inicio>(contenidoJSON);
    }
    public void CrearUnArchivoDeGuardadoNuevo()
    {
        //Crea un nuevo archivo de guardado
        ArchivoDeGuardado_MenuInicio = Application.dataPath + "datos_MenuInicio.json";

        //Guarda los datos para que se termine de crear el archivo
        GuardarDatosMenu_Inicio();

        Debug.LogWarning("Fecha: " + DateTime.Now.ToString() + " Se creo un nuevo archivo de guardado del menu de inicio" + ArchivoDeGuardado_MenuInicio);
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncGuardarMensajes(int Mensaje)
    {
        if (Mensaje == 1 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: GuardarDatos_MenuInicio()" + " Script: ControladorMenu_Inicio" + " Debug.log: Los datos del menu de inicio se han guardado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }else if(Mensaje == 2 && controladorDatosMensajes != null && llamarfunciones != null)
        {
            //Lo agrega a la lista de mensajes
            controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: CargarDatos_MenuInicio()" + " Script: ControladorMenu_Inicio" + " Debug.log: Los datos del menu de inicio se han cargado exitosamente");

            //Guardar los nuevos mensajes en el archivo de texto
            llamarfunciones.llamarFuncControladorDatos(6);
        }else if(Mensaje == 3 && controladorDatosMensajes != null && llamarfunciones != null)
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
        cambioColorMenuInicio = (cambioColorMenuInicio == null) ? cambioColorMenuInicio = FindObjectOfType<CambioColorMenuInicio>() : cambioColorMenuInicio;
        DatosDeScriptsParaBaseDatos = (DatosDeScriptsParaBaseDatos == null) ? DatosDeScriptsParaBaseDatos = FindObjectOfType<DatosDeScriptsParaBaseDatos>() : DatosDeScriptsParaBaseDatos;
        controladorDatosMensajes = (controladorDatosMensajes == null) ? controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>() : controladorDatosMensajes;
        llamarfunciones = (llamarfunciones == null) ? llamarfunciones = FindObjectOfType<llamarFunciones>() : llamarfunciones;
        ControladorDatosMenu_Inicio_RESPALDO = (ControladorDatosMenu_Inicio_RESPALDO == null) ? ControladorDatosMenu_Inicio_RESPALDO = FindObjectOfType<ControladorDatosMenu_Inicio_RESPALDO>() : ControladorDatosMenu_Inicio_RESPALDO;
        Debug.Log("Se ah hecho referencias en el menu de inicio");
    }
}
