using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* this is the object that controls turns, when the map is over
just generally thte highest level thing in the tree
right now only does turns and some light set up
*/
public class game_controller : MonoBehaviour
{

    //all 4 players 
    //blue is you
    // yellow is ally so an AI you can give some commands to
    //red is foes
    // green is another ally but one you have no control over
    public player blue;
    public player yellow;
    public player red;
    public player green;

    public GameObject text;
    public mouseover box;
    public events trigger;
    public int turn_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        // just grabbing the players so the pointers have them
       blue = GameObject.FindGameObjectWithTag("player").GetComponent(typeof(player)) as player;
       yellow =  GameObject.FindGameObjectWithTag("ally player").GetComponent(typeof(player)) as player;
       green = GameObject.FindGameObjectWithTag("green player").GetComponent(typeof(player)) as player;
        red = GameObject.FindGameObjectWithTag("red player").GetComponent(typeof(player)) as player;
        box = GameObject.FindGameObjectWithTag("mouseover").GetComponent(typeof(mouseover)) as mouseover;
        trigger = GameObject.FindGameObjectWithTag("events").GetComponent(typeof(events)) as events;
    }
    // manages the players turns so as soon as one is done we go to the next player
    public void turnDone()
    {
        turn_count++;
        trigger.turn(turn_count);
        if (blue.turn == true)
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
    public void mouse(unit person)
    {
        box.take(person);
    }
    public void dropmouse()
    {
        box.loose();
    }
}
