using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGeneral : MonoBehaviour
{
    //------------------------------------------------------------------------------------------//
    //FUNCIONES UNITY---------------------------------------------------------------------------//
    //------------------------------------------------------------------------------------------//
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
