using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class EnnemieSquareBehavior : MonoBehaviour
{
    public float speed;


    private Rigidbody2D rb;
    private SpriteRenderer spRenderer;

    private bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Disactivate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (transform.right* speed));
    }

    public void ReActivate()
    {
        spRenderer.enabled = true;
        destroyed = false;
    }

    public void Disactivate()
    {
        spRenderer.enabled = false;
        destroyed = true;
    }
}
