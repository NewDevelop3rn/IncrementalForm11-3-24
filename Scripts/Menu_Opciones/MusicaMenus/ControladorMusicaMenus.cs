using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControladorMusicaMenus : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void VolumenMusicaMenus(float VolumenMusicaMenus)
    {
        audioMixer.SetFloat("VolumenMusicaMenus", Mathf.Log10(VolumenMusicaMenus) * 20);
    }
}
