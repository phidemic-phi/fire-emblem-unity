using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowPlayer : player
{
    public override void setup()
    {
        turn = false;
        allys.Add(GameObject.FindGameObjectWithTag("player").GetComponent(typeof(player)) as player);
        allys.Add(GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player);
    }
}
