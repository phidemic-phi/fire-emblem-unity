using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourSquare : MonoBehaviour
{

    //what happens when clicked on
    void OnMouseDown()
    {
        tile mum;
       mum = GetComponentInParent(typeof(tile)) as tile;
        mum.clicked();

    }
}
