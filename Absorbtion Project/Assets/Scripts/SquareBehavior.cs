using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    public float timer = 5;
    public float countdown = 5;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squareblock")
        {
            timer -= Time.deltaTime;
        
            if (timer < 0)
            {
                timer = countdown;
                Debug.Log("!!!");
            }
        }
    }

}
