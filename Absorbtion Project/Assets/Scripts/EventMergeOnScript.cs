using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EventMergeOnScript : MonoBehaviour
{
    public VisualEffect visualEffect;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        visualEffect = GetComponent<VisualEffect>(); 
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.magnitude >= 20)
        {
            visualEffect.SendEvent("SpeedOn");
        }
        else
        {
            visualEffect.SendEvent("SpeedOff");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Squareblock"))
        {
            visualEffect.SendEvent("MergeOn");
        }
    }
}
