using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
 * basic camera movement and only use of keyboard/controller ATM will change with time
*/
public class camera : MonoBehaviour
{
   
   
   
    public float speed;
    public bool move;
    private float moveForward;
    private float moveSide;

    private Rigidbody rb3d;
   

    // Start is called before the first frame update
    void Start()
    {
        move = true;
        
        rb3d = GetComponent<Rigidbody>();
        // look at MC
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            moveForward = Input.GetAxis("Vertical");
            moveSide = Input.GetAxis("Horizontal");
        }
        else
        {
            moveForward = 0;
            moveSide = 0;
        } 

        Vector3 movement = new Vector3(moveSide, 0,  moveForward);
        rb3d.AddForce(movement * speed);
       




    }

}

