using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : tile
{

    



    public override void getInfo(string name)
    {
        name = "wall";
    }
    public override void setValue()
    {
       cubeRenderer = GetComponent<Renderer>();

        red = 0f;
        green = 0f;
        blue = 0f;

        colour.r = red;
        colour.g = green;
        colour.b = blue;

        
        cubeRenderer.material.color = colour;



        def = 0;
        res = 0;
        avo = 0;

        foot = 99;
        armour = 99;
        mage = 99;
        knight = 99;
        fly = 99;
        theif = 99;
        footbeast = 99;
        beast = 99;
        footdragon = 99;
        dragon = 99;
        rafel = 99;
    }
}
