using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectorScript : MonoBehaviour
{
    public List<GameObject> square_selection;
    public bool bruh;
    public GameObject square_one;
    public GameObject square_two;
    private void Update()
    {
        
        if (Input.GetKeyDown("j"))
        {
            bruh = !bruh;
        }
        
        if (Input.GetKeyDown("j"))
        {
            
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit & bruh)
                {
                    Debug.Log(hit.transform.name);
                    square_one = hit.transform.gameObject;
                    var cubeRenderer = square_one.transform.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.red);
                }
                
                if (hit&bruh==false)
                {
                    Debug.Log(hit.transform.name);
                    var rb_square = square_one.GetComponent<Rigidbody2D>();
                    rb_square.constraints = RigidbodyConstraints2D.FreezePosition;
                    square_two = hit.transform.gameObject;
                    square_one.transform.SetParent(square_two.transform);
                    var cubeRenderer = square_two.transform.GetComponent<Renderer>();
                    cubeRenderer.material.SetColor("_Color", Color.red);
                    //Destroy(square_two);
                }
        }
        
        square_one.transform.RotateAround(square_two.transform.localPosition,Vector3.right,5 * Time.deltaTime);

    }
}
