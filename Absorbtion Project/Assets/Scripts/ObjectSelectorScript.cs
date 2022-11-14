using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectorScript : MonoBehaviour
{
    public List<GameObject> square_selection;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit=Physics2D.Raycast(rayPos, Vector2.zero, 0f);
         
            if (hit)
            {
                Debug.Log(hit.transform.name);
                return hit.transform.gameObject;
            
            }
            else return null;
        }
    }
}
