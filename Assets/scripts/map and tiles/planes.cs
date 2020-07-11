using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// adds extra info to the tile class
public class planes : tile
{

  


    public override void getInfo(string name)
    {

       
        name = "Planes";
        
    }
    public override void setValue()
    {  
        cubeRenderer = GetComponent<Renderer>();
        red = 0f;
        green = 1f;
        blue = 0f;

        colour.r = red;
        colour.g = green;
        colour.b = blue;
        cubeRenderer.material.color = colour;


        def = 0;
    res = 0;
    avo = 0;

    foot = 1;
    armour = 1;
    mage = 1;
    knight = 1;
    fly = 1;
    theif = 1;
    footbeast = 1;
    beast = 1;
    footdragon = 1;
    dragon = 1;
    rafel = 1;
    }


   

}
