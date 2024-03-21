using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneInstanceMusicaMenus : MonoBehaviour
{
    //Variables que usa a unity para el uso de funciones externas
    private static OneInstanceMusicaMenus instance;

    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance)
        {
            Destroy(gameObject);
        }
    }
}
