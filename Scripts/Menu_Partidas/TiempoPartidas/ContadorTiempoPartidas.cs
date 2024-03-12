using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorTiempoPartidas : MonoBehaviour
{
    ControladorDatosMensajes controladorDatosMensajes;
    llamarFunciones llamarfunciones;

    [Header("TiempoPartida1")]
    public float SegundosPartida1;
    public int MinutosPartida1;
    public int HorasPartida1;
    public int DiasPartida1;

    [Header("TiempoPartida2")]
    public float SegundosPartida2;
    public int MinutosPartida2;
    public int HorasPartida2;
    public int DiasPartida2;

    [Header("TiempoPartida3")]
    public float SegundosPartida3;
    public int MinutosPartida3;
    public int HorasPartida3;
    public int DiasPartida3;

    public bool EnPartida1 = false;
    public bool EnPartida2 = false;
    public bool EnPartida3 = false;
    void Update()
    {
        ReorganizacionEnPartidas();
        ContadorTiempo();
    }

    private void Start()
    {
        controladorDatosMensajes = FindObjectOfType<ControladorDatosMensajes>();
        llamarfunciones = FindObjectOfType<llamarFunciones>();
    }
    public void EnPartida(int Partida)
    {
        switch(Partida)
        {
            case 1: EnPartida1 = true;
                 //Cambiar los valores en los otros scripts
                 GameObject.Find("Partida2").GetComponent<ContadorTiempoPartidas>().EnPartida2 = false;
                 GameObject.Find("Partida3").GetComponent<ContadorTiempoPartidas>().EnPartida3 = false;

                //Lo agrega a la lista de mensajes
                controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: EnPartida()" + " Script: ContadorTiempoPartidas" + " Debug.log: Se encuentra en partida:" + Partida);

                llamarfunciones.llamarFuncControladorDatos(6);

                break;

            case 2: EnPartida2 = true;
                //Cambiar los valores en los otros scripts
                GameObject.Find("Partida1").GetComponent<ContadorTiempoPartidas>().EnPartida1 = false;
                GameObject.Find("Partida3").GetComponent<ContadorTiempoPartidas>().EnPartida3 = false;

                //Lo agrega a la lista de mensajes
                controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: EnPartida()" + " Script: ContadorTiempoPartidas" + " Debug.log: Se encuentra en partida:" + Partida);

                llamarfunciones.llamarFuncControladorDatos(6);

                break;

            case 3: EnPartida3 = true;
                //Cambiar los valores en los otros scripts
                GameObject.Find("Partida1").GetComponent<ContadorTiempoPartidas>().EnPartida1 = false;
                GameObject.Find("Partida2").GetComponent<ContadorTiempoPartidas>().EnPartida2 = false;

                //Lo agrega a la lista de mensajes
                controladorDatosMensajes.Debugs = ("Tipo: Aviso " + " Fecha: " + DateTime.Now + " Funcion: EnPartida()" + " Script: ContadorTiempoPartidas" + " Debug.log: Se encuentra en partida:" + Partida);

                llamarfunciones.llamarFuncControladorDatos(6);

                break;
        }
    }
    public void ReorganizacionEnPartidas()
    {
        if (EnPartida1)
        {
            EnPartida2 = false;
            EnPartida3 = false;
        }
        else if (EnPartida2)
        {
            EnPartida1 = false;
            EnPartida3 = false;
        }
        else if (EnPartida3)
        {
            EnPartida1 = false;
            EnPartida2 = false;
        }
        else
        {
            EnPartida1 = false;
            EnPartida2 = false;
            EnPartida3 = false;
        }
    }
    public void ContadorTiempo()
    {
        if (EnPartida1)
        {
            SegundosPartida1 = SegundosPartida1 + Time.deltaTime;
            if (SegundosPartida1 > 60)
            {
                SegundosPartida1 = 0;
                MinutosPartida1++;
                if (MinutosPartida1 > 60)
                {
                    MinutosPartida1 = 0;
                    HorasPartida1++;
                    if (HorasPartida1 > 24)
                    {
                        HorasPartida1 = 0;
                        DiasPartida1++;
                    }
                }
            }
        }
        else if (EnPartida2)
        {
            SegundosPartida2 = SegundosPartida2 + Time.deltaTime;
            if (SegundosPartida2 > 60)
            {
                SegundosPartida2 = 0;
                MinutosPartida2++;
                if (MinutosPartida2 > 60)
                {
                    MinutosPartida2 = 0;
                    HorasPartida2++;
                    if (HorasPartida2 > 24)
                    {
                        HorasPartida2 = 0;
                        DiasPartida2++;
                    }
                }
            }
        }
        else if (EnPartida3)
        {
            SegundosPartida3 = SegundosPartida3 + Time.deltaTime;
            if (SegundosPartida3 > 60)
            {
                SegundosPartida3 = 0;
                MinutosPartida3++;
                if (MinutosPartida3 > 60)
                {
                    MinutosPartida3 = 0;
                    HorasPartida3++;
                    if (HorasPartida3 > 24)
                    {
                        HorasPartida3 = 0;
                        DiasPartida3++;
                    }
                }
            }
        }
        else
        {
            //No nos encontramos en partida
        }
    }
    public void MostrarTiempo()
    {
        GameObject.Find("TiempoJugadoPartida1").GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:00}", GameObject.Find("Partida1").GetComponent<ContadorTiempoPartidas>().DiasPartida1, GameObject.Find("Partida1").GetComponent<ContadorTiempoPartidas>().HorasPartida1, GameObject.Find("Partida1").GetComponent<ContadorTiempoPartidas>().MinutosPartida1);
        GameObject.Find("TiempoJugadoPartida2").GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:00}", GameObject.Find("Partida2").GetComponent<ContadorTiempoPartidas>().DiasPartida2, GameObject.Find("Partida2").GetComponent<ContadorTiempoPartidas>().HorasPartida2, GameObject.Find("Partida2").GetComponent<ContadorTiempoPartidas>().MinutosPartida2);
        GameObject.Find("TiempoJugadoPartida3").GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:00}", GameObject.Find("Partida3").GetComponent<ContadorTiempoPartidas>().DiasPartida3, GameObject.Find("Partida3").GetComponent<ContadorTiempoPartidas>().HorasPartida3, GameObject.Find("Partida3").GetComponent<ContadorTiempoPartidas>().MinutosPartida3);
    }
}
