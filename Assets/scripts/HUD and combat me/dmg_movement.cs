using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg_movement : MonoBehaviour
{
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
       


    }

    // Update is called once per frame
    void Update()
    {
        trans.position = trans.position + new Vector3(0, 0.005f, 0);


    }
}
