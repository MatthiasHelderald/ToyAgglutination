using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public SquareSpawner squareSpawner;
    public FindAllSquare findAllSquare;

    public Image image;
    public Color c;

    float timer = 0f;
    public float transitionTimer = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 1)
        {
            c = image.color;
            c.a = (-timer+1);
            image.color = c;
        }
        if (timer >= transitionTimer)
        {
            if(squareSpawner.squareIndex < 7)
                {squareSpawner.squareIndex ++;}
            if(squareSpawner.squareIndex == 7)
                {squareSpawner.squareIndex = 0;}
            
            foreach (SquareBehavior block in findAllSquare.blocks)
            {
                Transform gbTransform = block.transform;
                Vector3 vel = block.gameObject.GetComponent<Rigidbody2D>().velocity;
                Destroy(block.gameObject);
                GameObject newbloc = Instantiate(squareSpawner.square_selection[squareSpawner.squareIndex]);
                newbloc.gameObject.transform.position = gbTransform.position;
                newbloc.gameObject.transform.rotation = gbTransform.rotation;
                newbloc.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
                newbloc.gameObject.GetComponent<SquareBehavior>().drag = block.drag;
            }
            findAllSquare.blocks = (SquareBehavior[])FindObjectsOfType (typeof (SquareBehavior));
            timer = 0;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Transition");
        }
        if (timer >= transitionTimer-1)
        {
            c = image.color;
            c.a = ((timer-9)/(transitionTimer-9));
            c.a = (timer-9)/(transitionTimer-9);
            image.color = c;
        }
    }
}
