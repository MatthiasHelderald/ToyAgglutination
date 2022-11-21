using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall_one;
    public GameObject wall_two;
    private GameObject newwall;
    private GameObject newwall1;
    public bool alternator;
    void Update()
    {
        
        
        if (Input.GetKeyDown("h"))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray.z = 0;
            newwall = Instantiate(wall.gameObject,ray,transform.rotation);
            
           
            
        }
        if (Input.GetKey("h"))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            //worldPosition. = 0;
            Vector2 mousePos_rotate = Vector3.RotateTowards(newwall.transform.position,worldPosition,Mathf.Infinity,Mathf.Infinity)* 50 *Time.deltaTime;
            newwall.transform.rotation = Quaternion.LookRotation(mousePos_rotate);
        }
        
        
        // if (Input.GetKeyUp("h"))
        // {
        //     alternator = !alternator;
        // }
        //
        // if (Input.GetKeyDown("h"))
        // {
        //     if (alternator)
        //     {
        //         Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //         ray.z = 0;
        //         newwall = Instantiate(wall_one.gameObject,ray,transform.rotation);
        //     }
        //     if (alternator == false)
        //     {
        //         Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //         ray.z = 0;
        //         newwall1 = Instantiate(wall_two.gameObject, ray, transform.rotation);
        //         newwall.transform.SetParent(newwall1.transform);
        //         Instantiate(wall, newwall.transform.position, transform.rotation);
        //         wall.transform.position = (Vector3.RotateTowards(newwall.transform.position,newwall1.transform.position,360f,360));
        //     }
        // }
    }
}
