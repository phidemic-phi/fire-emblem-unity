using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePlayer : player
{

    //grabs allys and foes
    // will add AI type stuff here later
    public override void setup()
    {
        turn = true;
        allys.Add(this);
        allys.Add(GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player);
        allys.Add(GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player);
    }
    public override void dropMenu(unit person)
    {
        hud.dropItem( person);
    }
}
