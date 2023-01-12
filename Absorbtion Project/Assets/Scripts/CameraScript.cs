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
    [Header("Mouvement camera")]
    [Tooltip("Vitesse de suivie de la souris, Bas = fluide mais suis mal la souris / Haut = suis trÃ¨s bien la souris")]
    public float dragForce = 50;
    [Tooltip("Ralentissement en %, Bas = lent / Haut = Rapide")]
    public float ralentissement = 10f;

    private float originalSize;

    private Camera thisCamera;

    private Vector2 mousePos;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        body = transform.gameObject.GetComponent<Rigidbody2D>();
        originalSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize + 10, Time.deltaTime * zoomSpeed);
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            zumm += 1;
        }
        if (Input.mouseScrollDelta.y > 0 && zumm >= 1)
        {
            zumm -= 1;
        }
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

    void FixedUpdate()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (drag == true)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            body.velocity = new Vector2((worldPosition.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) * dragForce, (worldPosition.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y) * dragForce);
            mousePos = Input.mousePosition;
        }
        body.velocity = body.velocity * ralentissement / 100;
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }

}