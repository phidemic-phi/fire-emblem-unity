using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// adds extra info to the tile class
public class wall : tile
{

    



    public override void getInfo(string name)
    {
        name = "wall";
    }
    public override void setValue()
    {
       


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
