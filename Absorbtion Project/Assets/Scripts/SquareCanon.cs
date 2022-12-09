using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCanon : MonoBehaviour
{
    public GameObject square;
    public int timer = 5;
    public int timerMin = 5;
    public int timerMax = 5;
    public float timerTime;
    public float force = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<timerTime)
        {
            GameObject spawned = Instantiate(square.gameObject,transform.position,transform.rotation);
            spawned.GetComponent<Rigidbody2D>().velocity = transform.right * force;
            timerTime = 0;
            timer = Random.Range(timerMin, timerMax);
        }
        else
        {
            timerTime += Time.deltaTime;
        }
    }
}
