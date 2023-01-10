using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.EventInstance event_music;
    private bool MusicActive;

    void Start()
    {
        MusicActive = false;
        event_music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Musicless");
        instance.start();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            MusicActive = true;
        }
        if (MusicActive == true)
        {
            event_music.start();
        }
    }
}
