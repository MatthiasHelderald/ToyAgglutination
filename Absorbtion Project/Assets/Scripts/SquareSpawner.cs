using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public List<GameObject> square_selection;
    public int squareIndex = 0;
    public bool mouseOnObject = false;

    public float timer = 0.1f;
    float currentTime;
    void Update()
    {
        square = square_selection[squareIndex];
        //if (Input.GetMouseButtonDown(0) && mouseOnObject == false)
        {
            //timer = currentTime;
        }
        if (Input.GetMouseButtonDown(0) && mouseOnObject == false)
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.z = 0;
            Instantiate(square.gameObject,ray,transform.rotation);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Spawn" + (squareIndex).ToString());

            if (timer < currentTime)
            {
                //Instantiate(square.gameObject,ray,transform.rotation);
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
        if (Input.GetKeyDown("+") || Input.GetKeyDown("p"))
        {
            if (squareIndex == square_selection.Count-1)
            {
                squareIndex = 0;
                square = square_selection[squareIndex];
            }
            else
            {
                squareIndex += 1;
                square = square_selection[squareIndex];
            }
            Debug.ClearDeveloperConsole();
            Debug.Log(square_selection[squareIndex].name);
        }
        if (Input.GetKeyDown("-") || Input.GetKeyDown("m"))
        {
            if (squareIndex == 0)
            {
                squareIndex = square_selection.Count-1;
                square = square_selection[squareIndex];
            }
            else
            {
                squareIndex -= 1;
                square = square_selection[squareIndex];
            }
            Debug.ClearDeveloperConsole();
            Debug.Log(square_selection[squareIndex].name);
        }
    }
}
