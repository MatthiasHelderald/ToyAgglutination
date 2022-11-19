using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 5.0f;

    private int zum = 1;
    private int zumm = 1;

    private float originalSize = 0f;

    private Camera thisCamera;

// Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

// Update is called once per frame
    void Update()
    {
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, 
                targetSize, Time.deltaTime * zoomSpeed);
        }
        
        if (Input.mouseScrollDelta.y < 0)
        {
            zum += 1;
            
            if (zum >= 1)
            {
                zumm += 1;
                zum = 0;
            }
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            zum -= 1;
            
            if (zum <= -1)
            {
                zumm -= 1;
                zum = 0;
            }
        }
        zoomFactor = Mathf.Clamp(zumm,1,Mathf.Infinity);
        zoomFactor = zumm;
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }

}
