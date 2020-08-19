using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberbounce : MonoBehaviour
{
    Rigidbody2D body;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
         if(transform.localPosition.y < 3.5)
        {
            body.AddForce(transform.up * thrust);
      }
     }
}
