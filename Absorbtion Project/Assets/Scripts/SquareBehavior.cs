using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    public float timer = 5;
    public float countdown = 5;
    public int mergecounter = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Squareblock"))
        {
            timer -= Time.deltaTime;
        
            if (timer < 0)
            {
                timer = countdown;
                Debug.Log("!!!");
                
                mergecounter = +1;
                int mergecompare = collision.GetComponent<SquareBehavior>().mergecounter;
                
                if (mergecounter > mergecompare)
                {
                    Destroy(collision.gameObject);
                    Debug.Log("Destroyed other");
                }
                else
                {
                     Destroy(transform.gameObject);
                     Debug.Log("Self");
                }

            }
        }
    }

}
