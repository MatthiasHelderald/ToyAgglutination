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

    private Rigidbody2D body;
    bool drag = false;
    public float dragForce = 50;

    private float originalSize = 0f;

    private Camera thisCamera;

    private Vector2 mousePos;

    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    // Use this for initialization
    void Start()
    {
        //thisCamera = GetComponent<Camera>();
        //body = transform.gameObject.GetComponent<Rigidbody2D>();
        //originalSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.07f);
        }

        /*float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize =
                Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
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

        zoomFactor = Mathf.Clamp(zumm, 1, Mathf.Infinity);
        zoomFactor = zumm;

        if (Input.GetMouseButtonDown(2))
        {
            drag = true;
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(2))
        {
            drag = false;
        }
    }

    //void FixedUpdate()
    
        /*
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (drag == true)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            body.velocity =
                new Vector2((worldPosition.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) * dragForce,
                    (worldPosition.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y) * dragForce);
            mousePos = Input.mousePosition;
        }

        body.velocity = body.velocity / 1.1f;
    }*/

        void SetZoom(float zoomFactor)
        {
            this.zoomFactor = zoomFactor;
        }

        void zoom(float increment)
        {
            Camera.main.orthographicSize =
                Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        }
    }
}

