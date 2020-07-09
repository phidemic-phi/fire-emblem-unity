using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : tile
{

   



    public override void getInfo(string name)
    {
        name = "bush";
    }
    public override void setValue()
    {
       cubeRenderer = GetComponent<Renderer>();



        red = 0.0257209f;
        green = 0.3207547f;
        blue = 0.1571333f;

        colour.r = red;
        colour.g = green;
        colour.b = blue;
        
        cubeRenderer.material.color = colour;  



        def = 1;
        res = 0;
        avo = 10;

        foot = 2;
        armour = 3;
        mage = 2;
        knight = 3;
        fly = 1;
        theif = 1;
        footbeast = 2;
        beast = 1;
        footdragon = 2;
        dragon = 1;
        rafel = 1;
    }
}
