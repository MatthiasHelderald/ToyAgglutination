using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurBehavior : MonoBehaviour
{
    public int coté;
    public int hautBas;
    public int posNeg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag ==  "Squareblock")
        {
            col.gameObject.transform.position = new Vector3(-col.gameObject.transform.position.x*coté+posNeg, -col.gameObject.transform.position.y*hautBas+posNeg, col.gameObject.transform.position.z);
        }
    }
}
