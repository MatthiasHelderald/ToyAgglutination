using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBehavior : MonoBehaviour
{
    public GameObject sortie;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ennemie")
        {
            col.transform.position = sortie.transform.position;
            col.GetComponent<EnnemieSquareBehavior>().ReActivate();
        }
    }
}
