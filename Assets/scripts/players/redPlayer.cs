﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPlayer : player
{
    public override void setup()
    {
        turn = false;
        foes.Add(GameObject.FindGameObjectWithTag("player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player);
        foes.Add(GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player);
       
    }
}
