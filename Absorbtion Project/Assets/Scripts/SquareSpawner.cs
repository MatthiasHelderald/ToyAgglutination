using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public bool mouseOnObject = false;

    public float timer = 0.1f;
    float currentTime;
    void Update()
    {
        if (Input.GetMouseButton(0) && mouseOnObject == false)
        {
            if (timer < currentTime)
            {
                Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ray.z = 0;
                Instantiate(square.gameObject,ray,transform.rotation);
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
    }
}
