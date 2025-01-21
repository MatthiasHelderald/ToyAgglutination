using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.VFX;

public class SquareBehavior : MonoBehaviour
{
    private Rigidbody2D body;
    private Renderer cubeRenderer;

    public enum SquareTypes {
        normal,
        orbite,
        boid,
        blackhole
    }
    [Header("Etat du grab")]
    public SquareTypes mySquareType;
    private bool rot;

    [Tooltip("Froce du Grab")]
    public float gradForce = 50;
    public float maxSpeed = 50;

    public FindAllSquare findAllSquare;
    public SquareSpawner squareSpawner;
    public VisualEffect visualEffect;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cubeRenderer = GetComponent<Renderer>();
        findAllSquare = GameObject.Find("GameManager").GetComponent<FindAllSquare>();
        squareSpawner = GameObject.Find("GameManager").GetComponent<SquareSpawner>();
    }

    void Update()
    {
        if (body.velocity.magnitude >maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }
        //body.velocity = body.velocity * 0.95f;
    }

    
    void FixedUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        switch(mySquareType)
        {
            case SquareTypes.normal:
                body.velocity = new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce);
                break;
            case SquareTypes.boid:
                if (Vector2.Distance(worldPosition,transform.position) >= 20)
                {
                    body.AddForce(new Vector2((worldPosition.x - transform.position.x), (worldPosition.y - transform.position.y)));
                }
                break;
            case SquareTypes.orbite:
                body.AddForce(new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce));
                break;
            case SquareTypes.blackhole:
                body.velocity = new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce);
                break;
        }
    }
}
