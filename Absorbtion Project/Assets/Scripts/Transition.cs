using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public SquareSpawner squareSpawner;
    public FindAllSquare findAllSquare;
    public BackgroundBehavior backgroundBehavior;

    public Image image;
    public Color c;

    float timer = 0f;
    public float transitionTimer = 10;

    float transiSons1;
    float transiSons2;

    public Vector2 mousePos;
    public Vector2 worldPosition;

    public Vector2 mouseDelta
    {
        get
        {
            return new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - worldPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 2)
        {
            c = image.color;
            c.a = (-timer+2)/2;
            image.color = c;

            transiSons1 = -80 + c.a*40;
            backgroundBehavior.event_music.setParameterByName("transi"+(squareSpawner.squareIndex).ToString(), transiSons1);
            backgroundBehavior.event_grab.setParameterByName("transi"+(squareSpawner.squareIndex).ToString(), transiSons1);
            transiSons2 = -80 - transiSons1;
            backgroundBehavior.event_music.setParameterByName("transi"+(squareSpawner.squareIndex+1).ToString(), transiSons2);
            backgroundBehavior.event_grab.setParameterByName("transi"+(squareSpawner.squareIndex+1).ToString(), transiSons2);

        }

        if (timer >= transitionTimer)
        {
            if(squareSpawner.squareIndex < 6)
                {squareSpawner.squareIndex ++;}
            if(squareSpawner.squareIndex == 6)
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
        }
        if (timer >= transitionTimer-2)
        {
            c = image.color;
            c.a = (timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2));
            image.color = c;

            transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
            backgroundBehavior.event_music.setParameterByName("transi"+(squareSpawner.squareIndex+1).ToString(), transiSons1);
            backgroundBehavior.event_grab.setParameterByName("transi"+(squareSpawner.squareIndex+1).ToString(), transiSons1);
            transiSons2 = -80 - transiSons1;

            if (squareSpawner.squareIndex != 5)
            {
                backgroundBehavior.event_music.setParameterByName("transi"+(squareSpawner.squareIndex+2).ToString(), transiSons2);
                backgroundBehavior.event_grab.setParameterByName("transi"+(squareSpawner.squareIndex+2).ToString(), transiSons2);
            }

            else
            {
                backgroundBehavior.event_music.setParameterByName("transi1", transiSons2);
                backgroundBehavior.event_grab.setParameterByName("transi1", transiSons2);
            }
        }
    }
    void FixedUpdate() 
    {
        mousePos = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        backgroundBehavior.event_grab.setParameterByName("Speed", mouseDelta.magnitude);
    }
}
