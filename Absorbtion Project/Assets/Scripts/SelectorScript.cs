using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject square;
    public bool selected = false;
    //public List<GameObject> haha;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var cubeRenderer = gameObject.GetComponent<SquareBehavior>().GetComponent<Renderer>();
            selected = true;
        }
        
        if (selected == true)
        {
            var blocks = FindObjectOfType<SelectorScript>(selected==true);
            //haha.Add(blocks.gameObject);
            selected = false;
            Debug.Log(blocks.gameObject.transform.position);
        }
    }

}

