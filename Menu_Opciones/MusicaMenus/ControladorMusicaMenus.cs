using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControladorMusicaMenus : MonoBehaviour
{
    /*
     * 
     */

    //Variables que usa a unity para el uso de funciones externas
    [SerializeField] private AudioMixer audioMixer;

    //------------------------------------------------------------------------------------------//
    //FUNCION PARA ACTUALIZAR EL VOLUMEN--------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    public void VolumenMusicaMenus(float VolumenMusicaMenus)
    {
        audioMixer.SetFloat("VolumenMusicaMenus", Mathf.Log10(VolumenMusicaMenus) * 20);
    }
}
