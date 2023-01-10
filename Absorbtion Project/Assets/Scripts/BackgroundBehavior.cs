using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.EventInstance event_music;
    private bool MusicActive;

    private int transiValue = 0;

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
            MusicActive = true;
        }
        if (MusicActive == true)
        {
            if (transiValue < 300)
            {
                transiValue++;
                instance.setParameterByName("Fade", transiValue);
            }
            else
            {
                instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                event_music.start();
            }
        }
        if (Input.GetKeyDown("x"))
        {
            MusicActive = false;
            event_music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.start();
            if (transiValue > 1)
            {
                transiValue--;
                instance.setParameterByName("Fade", transiValue);
            }
        }
    }
}
