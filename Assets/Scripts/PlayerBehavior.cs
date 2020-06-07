using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 1.0f;
    private int angle = 45;
    private float t;
    private bool mousePressed = false;
    public bool stopMovement = true;
    public float inCreaseThrusInSec = 20f;

    void Start()
    {
        InvokeRepeating("IncreaseThrust", 0f, inCreaseThrusInSec);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            mousePressed = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mousePressed)
        {
            angle = -angle;
        }

        if (stopMovement)
        {
            if(Time.time > 2)
            {
                Movement();
            }
        }

        mousePressed = false;
    }

    public void Movement()
    {
        Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward.normalized;
        transform.Translate(dir * thrust * Time.fixedDeltaTime);
    }

    public void IncreaseThrust()
    {
        thrust++;
    }


}

