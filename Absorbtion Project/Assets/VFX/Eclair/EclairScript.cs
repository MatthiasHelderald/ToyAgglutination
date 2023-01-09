using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EclairScript : MonoBehaviour
{
    public VisualEffect visualEffect;
    public SquareBehavior squareBehavior;
    // Start is called before the first frame update
    void Start()
    {
        visualEffect = GetComponent<VisualEffect>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col) 
    {
        
        visualEffect.SetFloat("Longueur", (transform.position - col.gameObject.transform.position).magnitude / squareBehavior.mergecounter);
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(col.gameObject.transform.position.y - transform.position.y , col.gameObject.transform.position.x-transform.position.x) * 180 / Mathf.PI +90, Vector3.forward);
        visualEffect.SendEvent("CollisionOn");
    }
}
