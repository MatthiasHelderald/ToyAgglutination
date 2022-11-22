using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public bool mouseOnObject = false;
    private GameObject new_square;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseOnObject == false)
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.z = 0;
            Instantiate(square.gameObject,ray,transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.A) && mouseOnObject == false)
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.z = 0;
            new_square = Instantiate(square.gameObject,ray,transform.rotation);
            var cubeRenderer = new_square.transform.GetComponent<SquareBehavior>().GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.blue);

        }
    }
}
