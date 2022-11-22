using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSquareBehavior : MonoBehaviour
{
    public float timer = 5;
    public float countdown = 5;
    public int mergecounter = 0;
    private Vector2 movement;
    private Rigidbody2D body;

    float mass;
    public float gravityMultiplier = 10;

    public bool drag = false;
    public float gradForce = 50;

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
            {
                {
                }
                int mergecompare = collision.gameObject.GetComponent<SquareBehavior>().mergecounter;
                Debug.Log(mergecounter);
                    
                {
                    Destroy(collision.gameObject);

                    transform.localScale = new Vector2(0.5f / mergecounter, 0.5f / mergecounter);

                }
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            drag = false;
        }
    }
    //pour générer de la gravité avec tout les objets
    void FixedUpdate()
    {
        body.mass = mergecounter+1;
        AntiSquareBehavior[] blocks = (AntiSquareBehavior[])FindObjectsOfType (typeof (AntiSquareBehavior));
        foreach (AntiSquareBehavior block in blocks)
        {
            float distance = Vector2.Distance(block.transform.position, transform.position);
            if (distance != 0)
            {
                mass = mergecounter+1;
                //block.GetComponent<Rigidbody2D>().AddForce(-1 * new Vector2(block.transform.position.x - transform.position.x, block.transform.position.y - transform.position.y).normalized * (mass * block.mass /distance)*gravityMultiplier);
                block.GetComponent<Rigidbody2D>().AddForce(-1 * new Vector2(block.transform.position.x - transform.position.x, block.transform.position.y - transform.position.y).normalized * (mass * block.mass / Mathf.Pow(distance, 2f))*gravityMultiplier);
            }
            
        }
        
        if (drag == true)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            //transform.position = worldPosition;
            //body.velocity = new Vector2(0,0);
            body.position = worldPosition;
            body.AddForce(new Vector2((worldPosition.x - transform.position.x) * gradForce, (worldPosition.y - transform.position.y)*gradForce));
            
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
