using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class llamarFunciones : MonoBehaviour
{
    /*
     * Dependiendo de la funcion que es llamada, llama a una funcion de una seccion
     */

    //Referencias a otros scripts
    [Header("Controlador datos")]
    ControladorDatosMenu_Inicio controladorDatosMenu_inicio;
    ControladorDatosMenu_Partidas controladorDatosMenu_Partidas;
    ControladorDatosMenu_Opciones controladorDatosMenu_Opciones;
    ControladorDatosMensajes controladorDatosMensajes;

    [Header("Salir Juego")]
    SalirJuego salirJuego;

    [Header("Referencias")]
    AnimTitulo animTitulo;
    AnimPantallasNegras animPantallasNegras;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Start()
    {
        //Referencias
        FuncReferencias();
    }

    //------------------------------------------------------------------------------------------//
    //LLAMA FUNCIONES DE LA SECCION DE CONTROLADORES--------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void llamarFuncControladorDatos(int Funcionllamar)
    {
        //Referencias
        FuncReferencias();

        //llama a una funcion dependiendo sea el caso
        switch (Funcionllamar)
        {
            case 0: controladorDatosMenu_inicio.GuardarDatosMenu_Inicio(); break;

            case 1: controladorDatosMenu_inicio.CargarDatos_MenuInicio(); break;

            case 2: controladorDatosMenu_Partidas.GuardarDatos_MenuPartidas(); break;

            case 3: controladorDatosMenu_Partidas.CargarDatos_MenuPartidas(); break;

            case 4: controladorDatosMenu_Opciones.GuardarDatos_MenuOpciones(); break;

            case 5: controladorDatosMenu_Opciones.CargarDatos_MenuOpciones(); break;

            case 6: controladorDatosMensajes.GuardarDatos_Mensajes(); break;

        }
    }
    //------------------------------------------------------------------------------------------//
    //LLAMA A LA FUNCION PARA SALIR DEL JUEGO---------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void llamarfuncSalirJuego()
    {
        //Referencias
        FuncReferencias();

        //llama a la funcion para salir del juego
        salirJuego.funcSalirJuego();
    }
    //------------------------------------------------------------------------------------------//
    //LLAMA FUNCIONES DE LA SECCION DE ANIMACIONES----------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void AnimacionesUI(int Animacion)
    {
        //Referencias
        FuncReferencias();

        //llama a una funcion dependiendo sea el caso
        switch (Animacion)
        {
            case 1: animTitulo.PonerObjetosEnSuLugar(); break;

            case 2: animTitulo.MoverElTituloHaciaAlCentro(); break;

            case 3: animTitulo.MoverElTituloHaciaAbajo(); break;

            case 4: animPantallasNegras.PonerObjetosEnSuLugar(); break;

            case 5: animPantallasNegras.MoverPantalla1HaciaElCentroEntrada(); break;

            case 6: animPantallasNegras.MoverPantalla2HaciaElCentroEntrada(); break;

            case 7: animPantallasNegras.MoverPantalla1HaciaElCentroSalida(); break;

            case 8: animPantallasNegras.MoverPantalla2HaciaElCentroSalida(); break;

        }
    }
    //------------------------------------------------------------------------------------------//
    //LLAMA FUNCIONES DE LA SECCION DE REFERENCIAS----------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void Referencias(int Referencia)
    {
        //Referencias
        FuncReferencias();

        //llama a una funcion dependiendo sea el caso
        switch (Referencia)
        {
            case 1: controladorDatosMenu_inicio.FuncReferencias(); break;

            case 5: animTitulo.ReferenciaAlObjetoDeAnimacion(); break;

            case 6: animPantallasNegras.ReferenciaAlObjetoDeAnimacion(); break;
        }
    }
    //------------------------------------------------------------------------------------------//
    //FUNCIONES DE USO MULTIPLE-----------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void FuncReferencias()
    {
        //Referencias
        controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>();

        controladorDatosMenu_inicio = FindObjectOfType<ControladorDatosMenu_Inicio>();

        controladorDatosMenu_Partidas = FindObjectOfType<ControladorDatosMenu_Partidas>();

        controladorDatosMenu_Opciones = FindObjectOfType<ControladorDatosMenu_Opciones>();

        salirJuego = FindObjectOfType<SalirJuego>();

        animTitulo = FindObjectOfType<AnimTitulo>();

        animPantallasNegras = FindObjectOfType<AnimPantallasNegras>();
    }
}
