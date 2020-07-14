using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// adds extra info to the tile class
public class bush : tile
{

   



    public override void getInfo(string name)
    {
        name = "bush";
    }
    public override void setValue()
    {
        



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
