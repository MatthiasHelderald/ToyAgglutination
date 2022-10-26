using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject square;
    private void Update()
    {
        if (Input.GetKeyDown("x"))
        
        { 
            Vector2 ray = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ray);
            
            if (hit.transform.gameObject.CompareTag("Squareblock"))
            {
                int mergenumber = hit.transform.gameObject.GetComponent<SquareBehavior>().mergecounter;
                
                if (mergenumber > 1)
                {
                    for (int i = 1; i<mergenumber+1;i++)
                    {
                        Debug.Log("haha");
                        Instantiate(square);
                        //Destroy(hit.transform.gameObject);
                    }
                    
                }
            } 
        }
        
    }

}

