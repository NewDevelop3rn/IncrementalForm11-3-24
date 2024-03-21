using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneInstanceBaseDatos : MonoBehaviour
{
    //Variables que usa a unity para el uso de funciones externas
    private static OneInstanceBaseDatos instance;

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
