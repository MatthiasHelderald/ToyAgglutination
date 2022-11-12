using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject square;
    public List<GameObject> selectar;
    private void OnMouseOver()
    {
        if (Input.GetKeyDown("n"))
        
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
        

        if (Input.GetMouseButtonDown(1))
        {
            var cubeRenderer = gameObject.GetComponent<SquareBehavior>().GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
            selectar.Add(cubeRenderer.gameObject);
            if (selectar.Count == 2)
            {
                selectar[0].transform.Rotate(selectar[1].transform.position);
            }
        }
    }

}

