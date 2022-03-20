using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public bool loop;
    //public bool DinamicVolume;

    [Range(0f,1f)]
    public float voulume;

    [Range(0f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
