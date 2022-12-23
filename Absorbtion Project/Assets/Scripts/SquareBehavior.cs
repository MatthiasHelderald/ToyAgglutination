using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareBehavior : MonoBehaviour
{
    private Rigidbody2D body;
    private Renderer cubeRenderer;

    [Header("Timer")]
    public float timer = 5;
    public float countdown = 5;

    [Header("Nombre de merge")]
    public int mergecounter = 0;
    private Vector2 movement;

    [Header("BlackHole")]
    [Tooltip("Nombre de merge avant la création du trou noir")]
    public int blackholenb = 10;
    public bool blackholestate = false;

    public enum SquareTypes {
        normal,
        orbite,
        boid,
        blackhole
    }
    [Header("Etat du grab")]
    public SquareTypes mySquareType;

    float mass;
    [Tooltip("Froce de la gravité")]
    public float gravityMultiplier = 10;

    public bool drag = false;
    [Tooltip("Froce du Grab")]
    public float gradForce = 50;

    public FindAllSquare findAllSquare;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cubeRenderer = GetComponent<Renderer>();
        findAllSquare = GameObject.Find("FindAllGO").GetComponent<FindAllSquare>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Squareblock") && drag == false)
        {
            mergecounter += 1;
            if (mergecounter == blackholenb)
            {
                blackholestate = true;
                cubeRenderer.material.SetColor("_Color", Color.black);

                transform.localScale = new Vector2(50f * 0.75f, 50f * 0.75f);
                body.constraints = RigidbodyConstraints2D.FreezeAll;
                //mySquareType = SquareTypes.blackhole;
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
            //body.velocity = new Vector2(0,0);
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
        
    }
    //pour générer de la gravité avec tout les objets
    void FixedUpdate()
    {
        body.mass = mergecounter+1;
        mass = mergecounter+1;
        
        foreach (SquareBehavior block in findAllSquare.blocks)
        {
            float distance = Vector2.Distance(block.transform.position, transform.position);
            if (distance != 0 && distance <= 50)
            {
                body.AddForce(new Vector2(block.transform.position.x - transform.position.x, block.transform.position.y - transform.position.y).normalized * (mass * block.mass / Mathf.Pow(distance, 2f))*gravityMultiplier);
            }
        }
        
        if (drag == true)
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

    //Grab
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
