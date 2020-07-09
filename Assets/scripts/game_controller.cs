using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    public player blue;
    public player yellow;
    public player red;
    public player green;
    // Start is called before the first frame update
    void Start()
    {
       blue = GameObject.FindGameObjectWithTag("player").GetComponent(typeof(player)) as player;
       yellow =  GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player;
       green = GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player;
        red = GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player;
    }

    public void turnDone()
    {
        if(blue.turn == true)
        {
            blue.turn = false;
            yellow.turnStart();
        }
        else if (yellow.turn == true)
        {
            yellow.turn = false;
            red.turnStart();
        }
        else if (red.turn == true)
        {
            red.turn = false;
            green.turnStart();
        }
        else if (green.turn == true)
        {
            green.turn = false;
            blue.turnStart();
        }
    }
}
