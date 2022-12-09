using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectorScript : MonoBehaviour
{
    public List<GameObject> square_selection;
    public bool bruh;
    private GameObject square_one;
    private GameObject square_two;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            (GameObject, GameObject) Twins()
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit&bruh)
                {
                    Debug.Log(hit.transform.name);
                    //var selected_objet = hit.transform.gameObject;
                    //square_selection.Add(selected_objet);
                    square_one = hit.transform.gameObject;
                    bruh = false;
                }
                
                if (hit&!bruh)
                {
                    Debug.Log(hit.transform.name);
                    //var selected_objet = hit.transform.gameObject;
                    //square_selection.Add(selected_objet);
                    square_two = hit.transform.gameObject;
                    bruh = true;
                }

                return (square_one, square_two);
            }

            var jpp = Twins();
            Debug.Log($",{jpp.Item1},selected1");
        }

        
        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
}
