using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public FMOD.Studio.EventInstance event_music;
    private bool MusicActive;

    void Start()
    {
        MusicActive = false;
        event_music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Musicless");
        event_music.start();
        event_music.setParameterByName("transi1", -80);
        event_music.setParameterByName("transi2", -80);
        event_music.setParameterByName("transi3", -80);
        event_music.setParameterByName("transi4", -80);
        event_music.setParameterByName("transi5", -80);
        event_music.setParameterByName("transi6", -80);
        event_music.setParameterByName("transi7", -80);
    }

    void Update()
    {

    }
}
