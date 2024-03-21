using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneInstanceOtros : MonoBehaviour
{
    //Variables que usa a unity para el uso de funciones externas
    private static OneInstanceOtros instance;

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
