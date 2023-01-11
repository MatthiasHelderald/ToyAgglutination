using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    public FMOD.Studio.EventInstance event_grab;
    public FMOD.Studio.EventInstance event_music;

    void Start()
    {
        event_music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        event_grab = FMODUnity.RuntimeManager.CreateInstance("event:/Grab");
        event_music.start();
        event_grab.start();

        event_music.setParameterByName("transi1", -80);
        event_music.setParameterByName("transi2", -80);
        event_music.setParameterByName("transi3", -80);
        event_music.setParameterByName("transi4", -80);
        event_music.setParameterByName("transi5", -80);
        event_music.setParameterByName("transi6", -80);
        event_music.setParameterByName("transi7", -80);

        
        event_grab.setParameterByName("transi1", -80);
        event_grab.setParameterByName("transi2", -80);
        event_grab.setParameterByName("transi3", -80);
        event_grab.setParameterByName("transi4", -80);
        event_grab.setParameterByName("transi5", -80);
        event_grab.setParameterByName("transi6", -80);
        event_grab.setParameterByName("transi7", -80);
    }

    void Update()
    {

    }
}
