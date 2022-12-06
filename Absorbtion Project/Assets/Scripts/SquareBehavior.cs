using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareBehavior : MonoBehaviour
{
    public float timer = 5;
    public float countdown = 5;
    public int mergecounter = 0;
    private Vector2 movement;
    private Rigidbody2D body;
    private Renderer cubeRenderer;
    public int blackholenb = 10;
    public bool blackholestate = false;

    public enum SquareTypes {
        normal,
        boidC,
        boid,
        blackhole
    }

    public SquareTypes mySquareType;

    float mass;
    public float gravityMultiplier = 10;

    public bool drag = false;
    public float gradForce = 50;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cubeRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Squareblock") && drag == false)
        {
            body.velocity += collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            mergecounter += 1;
            if (mergecounter == blackholenb)
            {
                blackholestate = true;
                cubeRenderer.material.SetColor("_Color", Color.black);

                transform.localScale = new Vector2(50f * 0.75f, 50f * 0.75f);
                body.constraints = RigidbodyConstraints2D.FreezeAll;
                mySquareType = SquareTypes.blackhole;
                //On change la taille la couleur de l'objet
            }
            int mergecompare = collision.gameObject.GetComponent<SquareBehavior>().mergecounter;

            if (mergecounter > mergecompare & blackholestate == false)
            {
                Destroy(collision.gameObject);

                transform.localScale = new Vector2(0.5f * mergecounter, 0.5f * mergecounter);

            }
            if ( mergecounter > mergecompare & blackholestate & true)
            {
                Destroy(collision.gameObject);
            }
            body.velocity = new Vector2(0,0);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            drag = false;
        }

        if (Input.GetKeyDown("x"))
        {
            Destroy(gameObject);
        }

        switch(mySquareType)
        {
            case SquareTypes.normal:
                cubeRenderer.material.SetColor("_Color", Color.white);
                break;
            case SquareTypes.boidC:
                cubeRenderer.material.SetColor("_Color", Color.blue);
                break;
            case SquareTypes.boid:
                cubeRenderer.material.SetColor("_Color", Color.cyan);
                break;
            case SquareTypes.blackhole:
                cubeRenderer.material.SetColor("_Color", Color.black);
                break;
        }
    }
    //pour générer de la gravité avec tout les objets
    void FixedUpdate()
    {
        SquareBehavior[] blocks = (SquareBehavior[])FindObjectsOfType (typeof (SquareBehavior));
        switch(mySquareType)
        {
            case SquareTypes.normal:
                body.mass = mergecounter+1;
                foreach (SquareBehavior block in blocks)
                {
                    float distance = Vector2.Distance(block.transform.position, transform.position);
                    if (distance != 0 && distance <= 50)
                    {
                        mass = mergecounter+1;
                        body.AddForce(new Vector2(block.transform.position.x - transform.position.x, block.transform.position.y - transform.position.y).normalized * (mass * block.mass / Mathf.Pow(distance, 2f))*gravityMultiplier);
                    }
                    
                }
                break;
            case SquareTypes.boid:
                transform.Translate(transform.right*Time.deltaTime);
                break;
        }
        
        if (drag == true)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            //transform.position = worldPosition;
            //body.velocity = new Vector2(0,0);
            //body.position = worldPosition;
            switch(mySquareType)
            {
                case SquareTypes.normal:
                    body.AddForce(new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce));
                    break;

                case SquareTypes.boid:
                    if (Vector2.Distance(worldPosition,transform.position) >= 20)
                    {
                        body.AddForce(new Vector2((worldPosition.x - transform.position.x), (worldPosition.y - transform.position.y)));
                    }
                    break;
                case SquareTypes.boidC:
                    //body.velocity = new Vector2((worldPosition.x - transform.position.x), (worldPosition.y - transform.position.y)).normalized * gradForce;
                    body.velocity = new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce);
                    break;
            }
            
            
        }
    }

    void OnMouseOver() 
    {
        if (Input.GetMouseButton(1))
        {
            drag = true;
        }
        else
        {
            drag = false;
        }
    }
}
