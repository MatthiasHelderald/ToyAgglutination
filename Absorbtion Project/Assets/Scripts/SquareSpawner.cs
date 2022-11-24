using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public bool mouseOnObject = false;


    public enum SquareType
    {
        Normal,
        AntiCube,
        Attractor,
        Dead
    }

    public SquareType mySquareType;
    

    void Update()
    {
        if (mySquareType == SquareType.Normal)
        {
            if (Input.GetKeyDown(KeyCode.A) && mouseOnObject == false)
            {
                mySquareType = SquareType.AntiCube;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && mouseOnObject == false)
            {
                mySquareType = SquareType.Normal;
            }
        }
        
        
        switch (mySquareType)
        {
            case SquareType.Normal:
            {
                {
                    if (Input.GetMouseButtonDown(0) && mouseOnObject == false)
                    {
                        Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        ray.z = 0;
                        var squareObject = Instantiate(square.gameObject, ray, transform.rotation);
                        var squareBehavior = squareObject.GetComponent<SquareBehavior>();
                        squareBehavior.squareSpawner = this;
                        squareBehavior.squaretype = SquareType.Normal;
                    }
                }
            }
                break;
            
            case SquareType.AntiCube:
            {
                if (Input.GetKeyDown(KeyCode.A) && mouseOnObject == false)
                {
                    Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    ray.z = 0;
                    var anti_square = Instantiate(square.gameObject, ray, transform.rotation);
                    anti_square.tag = "Emoblock";
                    var cubeRenderer = anti_square.transform.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.blue);
                    var squareBehavior = anti_square.GetComponent<SquareBehavior>();
                    squareBehavior.squareSpawner = this;
                    squareBehavior.squaretype = SquareType.AntiCube;
                }
            }
                break;
        }

    }
}