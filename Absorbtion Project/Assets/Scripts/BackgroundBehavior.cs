using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Musicless");
        instance.start();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
