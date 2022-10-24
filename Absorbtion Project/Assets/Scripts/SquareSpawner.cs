using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.z = 0;
            Instantiate(square.gameObject,ray,transform.rotation);
        }
    }
}
