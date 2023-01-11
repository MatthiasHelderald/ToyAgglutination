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

    bool transition;

    float transiSons1;
    float transiSons2;

    private FMOD.Studio.EventInstance music;
    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("transi"+(squareSpawner.squareIndex).ToString());
        timer += Time.deltaTime;
        if (timer <= 2)
        {
            c = image.color;
            c.a = (-timer+2)/2;
            image.color = c;

            if (squareSpawner.squareIndex == 0)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi7", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi1", transiSons2);
            }
            if (squareSpawner.squareIndex == 1)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi1", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi2", transiSons2);
            }
            if (squareSpawner.squareIndex == 2)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi2", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi3", transiSons2);
            }
            if (squareSpawner.squareIndex == 3)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi3", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi4", transiSons2);
            }
            if (squareSpawner.squareIndex == 4)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi4", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi5", transiSons2);
            }
            if (squareSpawner.squareIndex == 5)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi5", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi6", transiSons2);
            }
            if (squareSpawner.squareIndex == 6)
            {
                transiSons1 = -80 + c.a*40;
                music.setParameterByName("transi6", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi7", transiSons2);
            }


            transition = true;
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
        }
        if (timer >= transitionTimer-2)
        {
            c = image.color;
            c.a = (timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2));
            image.color = c;

            if (squareSpawner.squareIndex == 0)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi7", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi1", transiSons2);
            }
            if (squareSpawner.squareIndex == 1)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi1", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi2", transiSons2);
            }
            if (squareSpawner.squareIndex == 2)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi2", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi3", transiSons2);
            }
            if (squareSpawner.squareIndex == 3)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi3", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi4", transiSons2);
            }
            if (squareSpawner.squareIndex == 4)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi4", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi5", transiSons2);
            }
            if (squareSpawner.squareIndex == 5)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi5", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi6", transiSons2);
            }
            if (squareSpawner.squareIndex == 6)
            {
                transiSons1 = -(timer-(transitionTimer-2))/(transitionTimer-(transitionTimer-2))*40;
                music.setParameterByName("transi6", transiSons1);
                transiSons2 = -80 - transiSons1;
                music.setParameterByName("transi7", transiSons2);
            }
        }
    }
}
