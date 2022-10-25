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

    private void Start()
    {
        body = transform.gameObject.GetComponent<Rigidbody2D>();
        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Squareblock"))
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = countdown;
                Debug.Log("!!!");

                mergecounter += 1;
                int mergecompare = collision.GetComponent<SquareBehavior>().mergecounter;

                if (mergecounter > mergecompare)
                {
                    Destroy(collision.gameObject);
                    Debug.Log("Destroyed other");

                    Vector2 objectscale = transform.localScale;
                    transform.localScale = new Vector2(objectscale.x * 1.2f, objectscale.y * 1.2f);
                }
                else
                {
                    Destroy(transform.gameObject);
                    Debug.Log("Self");
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mury"))
        {
            movement.y *= -1;
            movement.x += Random.Range(0,5);
            movement.y += Random.Range(0,5);
            body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
        }
        
        if (collision.gameObject.CompareTag("Murx"))
        {
            movement.x *= -1;
            movement.x += Random.Range(0,5);
            movement.y += Random.Range(0,5);
            body.AddForce(movement.normalized*5, ForceMode2D.Impulse);
        }
    }
    
}
