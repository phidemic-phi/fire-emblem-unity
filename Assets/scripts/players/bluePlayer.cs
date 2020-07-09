using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePlayer : player
{
    public override void setup()
    {
        turn = true;
        allys.Add(GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player);
        allys.Add(GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player);
    }
}
