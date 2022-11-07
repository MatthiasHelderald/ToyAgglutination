using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareBehavior : MonoBehaviour
{
    public float timer = 5;
    public float countdown = 5;
    public int mergecounter = 0;
    private Vector2 movement;
    private Rigidbody2D body;

    float mass;
    public float gravityMultiplier = 10;

    private void Start()
    {
        body = transform.gameObject.GetComponent<Rigidbody2D>();
        //movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        //body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mur") && false)
        {
            movement.y *= -1;
            movement.x += Random.Range(-5,5);
            movement.y += Random.Range(-5,5);
            body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
        }
        
        if (collision.gameObject.CompareTag("Murx") && false)
        {
            movement.x *= -1;
            movement.x += Random.Range(-5,5);
            movement.y += Random.Range(-5,5);
            body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Squareblock"))
        {

            mergecounter += 1;
            int mergecompare = collision.gameObject.GetComponent<SquareBehavior>().mergecounter;

            if (mergecounter > mergecompare)
            {
                Destroy(collision.gameObject);

                Vector2 objectscale = transform.localScale;
                transform.localScale = new Vector2(objectscale.x * 1.1f, objectscale.y * 1.1f);

                
                Vector2 objectScale = transform.localScale;
                transform.localScale = new Vector2(objectScale.x * 1.1f,objectScale.y*1.1f);

            }
            else
            {
                Destroy(transform.gameObject);
                //Debug.Log("Self");
            }
        }
    }

    //pour générer de la gravité avec tout les objets
    void FixedUpdate()
    {
        body.mass = mergecounter+1;
        SquareBehavior[] blocks = (SquareBehavior[])FindObjectsOfType (typeof (SquareBehavior));
        foreach (SquareBehavior block in blocks)
        {
            float distance = Vector2.Distance(block.transform.position, transform.position);
            if (distance != 0)
            {
                mass = mergecounter+1;
                block.GetComponent<Rigidbody2D>().AddForce(-1 * new Vector2(block.transform.position.x - transform.position.x, block.transform.position.y - transform.position.y).normalized * (mass * block.mass / Mathf.Pow(distance, 2f))*gravityMultiplier);
            }
            
        }
        
    }

    void OnMouseOver() 
    {
        Debug.Log("Detected");
    }
    void OnMouseExit() 
    {
        
    }
}
