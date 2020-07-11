using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenPlayer : player
{
    //grabs allys and foes
    // will add AI type stuff here later
    public override void setup()
    {
        turn = false;
        allys.Add(  GameObject.FindGameObjectWithTag("player").GetComponent(typeof(player)) as player);
        allys.Add(GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player);
    }
}
