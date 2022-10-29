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
            Vector3 ray = Input.mousePosition;
            ray.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(ray, ray);
            
            if (hit.transform.gameObject.CompareTag("Squareblock") && hit.transform.gameObject != null)
            {
                int mergenumber = hit.transform.gameObject.GetComponent<SquareBehavior>().mergecounter;
                
                if (mergenumber > 1)
                {
                    for (int i = 1; i<mergenumber+2;i++)
                    {
                        Debug.Log("haha");
                        Instantiate(square);
                        Destroy(hit.transform.gameObject);
                    }
                    
                }
            } 
            else{Debug.Log("rien");}
        }
        
    }

}

