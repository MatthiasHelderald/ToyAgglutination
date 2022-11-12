using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject square;
    private void OnMouseOver()
    {
        if (Input.GetKeyDown("x"))
        
        { 
            int mergenumber = gameObject.GetComponent<SquareBehavior>().mergecounter;
            if (mergenumber > 1)
            {
                for (int i = 1; i<mergenumber+2;i++)
                {
                    Debug.Log("haha");
                    Instantiate(square,gameObject.transform.position,gameObject.transform.rotation);
                    Destroy(gameObject);
                }

            } 
            else{Debug.Log("rien");}
        }
        
    }

}

