using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * base class of the 4 main playersright now just implementing the main functions of players
 */



    
public abstract class player : MonoBehaviour
{

    // is it my turn?
    public bool turn;

    //pointers to all things that could be helpful
    public List<unit> units = new List<unit>();
    public map Map;
    public List<player> foes = new List<player>();
    public List<player> allys = new List<player>();
    public game_controller god;
    public string teamName = "Dawn Brigade";
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        //loop to gather all of my units
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            units.Add(gameObject.transform.GetChild(i).gameObject.GetComponent(typeof(unit)) as unit);
         
        }
        Map = GameObject.FindGameObjectWithTag("map").GetComponent(typeof(map)) as map;
        god = GetComponentInParent(typeof(game_controller)) as game_controller;
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
      
        setup();
    }
   
    //what happens when a unit is clicked
    // mainly to tell the map and hHUD that a unit was clicked
    public bool unitClicked(unit guy)
    {
        if (hud.state == hudState.skillSelect && turn == true)
        {
            unitFight(guy);
        }
        else if (turn == true && hud.state != hudState.dropping)
        {
          
            hud.getunit(guy);
            Map.unitClicked(guy);
            return true;
        }
        return false;
    }

    public void mouse(unit person)
    {
        if (hud.state != hudState.attack)
            god.mouse(person);
        else
            hud.mouse(person);
    }
    public void dropmouse()
    {
        if (hud.state != hudState.attack)
            god.dropmouse();
        else
            hud.dropmouse();
    }


    public void unitFight(unit guy)
    {
      
            hud.fightUnit(guy);

    }


    //helper function, for do I have a unit at location?
    public bool isHere(Vector3 location)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].transform.position[0] == location[0])
                if (units[i].transform.position[2] == location[2])
                    return true;


        }
        return false;
    }

    //get the unit that is at location that I know you have
    public unit getHere(Vector3 location)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].transform.position[0] == location[0])
                if (units[i].transform.position[2] == location[2])
                    return units[i];


        }
        return null;
    }

    //do I have a unit here or do one of my allys?
    public bool allyHere(Vector3 location)
    {
        bool temp = isHere(location);

        for (int i = 0; i <allys.Count; i++)
        {
            if (temp == true)
                return true;
            temp = allys[i].isHere(location);              
       
        }
        return temp;
    }

    //does one of my foes have a unit here?
    public bool foeHere(Vector3 location)
    {
        bool temp = false;
        for (int i = 0; i < foes.Count; i++)
        {
            temp = foes[i].isHere(location);
            if (temp == true)
                return temp;
        }
        return temp;
    }
    public bool anyHere(Vector3 location)
    {
        if (foeHere(location) == true)
        {
            return true;
        }
        else
           return allyHere(location);
       
    }

    //get the foe that is at location 
    //should always use foe here before this so you know that you will grab one
    public unit getFoe(Vector3 location)
    {
       
        for (int i = 0; i < foes.Count; i++)
        {
            if (foes[i].isHere(location))
                return foes[i].getHere(location);
        }
        return null;
    }
    public unit getAlly(Vector3 location)
    {

        for (int i = 0; i < allys.Count; i++)
        {
            if (allys[i].isHere(location))
                return allys[i].getHere(location);
        }
        return null;
    }


    //what happens at the start of my turn
    public void turnStart()
    {
        turn = true;
        for (int i = 0; i < units.Count; i++)
        {
            units[i].turnStart();

        }
        if (units.Count== 0)
        {
           god.turnDone();
        }
    }

    //check to see if all my units have moved
    public void moveDone()
    {
        //clear();
        bool everyone = true;
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].state != unitState.done)
                everyone = false;
        }
        if (everyone == true)
        {
            god.turnDone();
        }
    }


    public void death (unit person)
    {
        for( int i = 0; i < units.Count; i++)
        {
           if( units[i]== person)
            {
                units.RemoveAt(i);
                Destroy(person.gameObject, 0.5f);
                return;
            }

        }
    }
    public void skillMarkAll(unit user)
    {
        Map.clearTiles();
        Vector3 location = user.transform.position;
        if (allyHere(location + Vector3.forward )== true || foeHere(location + Vector3.forward) == true)
        {
            Map.makeGreen(location + Vector3.forward);
        }
        if (allyHere(location + Vector3.back) == true || foeHere(location + Vector3.back) == true)
        {
            Map.makeGreen(location + Vector3.back);
        }
        if (allyHere(location + Vector3.left) == true || foeHere(location + Vector3.left) == true)
        {
            Map.makeGreen(location + Vector3.left);
        }
        if (allyHere(location + Vector3.right) == true || foeHere(location + Vector3.right) == true)
        {
            Map.makeGreen(location + Vector3.right);
        }

    }
    public void skillMarkAlly(unit user)
    {
        Map.clearTiles();
        Vector3 location = user.transform.position;
        if (allyHere(location + Vector3.forward) == true)
        {
            Map.makeGreen(location + Vector3.forward);
        }
        if (allyHere(location + Vector3.back) == true)
        {
            Map.makeGreen(location + Vector3.back);
        }
        if (allyHere(location + Vector3.left) == true)
        {
            Map.makeGreen(location + Vector3.left);
        }
        if (allyHere(location + Vector3.right) == true )
        {
            Map.makeGreen(location + Vector3.right);
        }
    }
    public void skillMarkFoe(unit user)
    {
        Map.clearTiles();
        Vector3 location = user.transform.position;
        if ( foeHere(location + Vector3.forward) == true)
        {
            Map.makeGreen(location + Vector3.forward);
        }
        if ( foeHere(location + Vector3.back) == true)
        {
            Map.makeGreen(location + Vector3.back);
        }
        if (foeHere(location + Vector3.left) == true)
        {
            Map.makeGreen(location + Vector3.left);
        }
        if ( foeHere(location + Vector3.right) == true)
        {
            Map.makeGreen(location + Vector3.right);
        }
    }
    public bool anyNextTo(unit user , skill ability)
    {
        Vector3 location = user.transform.position;
        if (allyHere(location + Vector3.forward) == true || foeHere(location + Vector3.forward) == true)
        {
            if (ability.useable(user, Vector3.forward, Map))
                 return true;
        }
        if (allyHere(location + Vector3.back) == true || foeHere(location + Vector3.back) == true)
        {
            if (ability.useable(user, Vector3.back, Map))
                return true;
        }
        if (allyHere(location + Vector3.left) == true || foeHere(location + Vector3.left) == true)
        {
            if (ability.useable(user, Vector3.left, Map))
                return true;
        }
        if (allyHere(location + Vector3.right) == true || foeHere(location + Vector3.right) == true)
        {
            if (ability.useable(user, Vector3.right, Map))
                return true;
        }
        return false;
    }
    public bool allyNextTo(unit user, skill ability)
    {
        Vector3 location = user.transform.position;
        if (allyHere(location + Vector3.forward) == true )
        {
            if (ability.useable(user, Vector3.forward, Map))
                return true;
        }
        if (allyHere(location + Vector3.back) == true )
        {
            if (ability.useable(user, Vector3.back, Map))
                return true;
        }
        if (allyHere(location + Vector3.left) == true )
        {
            if (ability.useable(user, Vector3.left, Map))
                return true;
        }
        if (allyHere(location + Vector3.right) == true )
        {
            if (ability.useable(user, Vector3.right, Map))
                return true;
        }
        return false;
    }
    public bool foeNextTo(unit user, skill ability)
    {
        Vector3 location = user.transform.position;
        if ( foeHere(location + Vector3.forward) == true)
        {
            if (ability.useable(user, Vector3.forward, Map))
                return true;
        }
        if ( foeHere(location + Vector3.back) == true)
        {
            if (ability.useable(user, Vector3.back, Map))
                return true;
        }
        if (foeHere(location + Vector3.left) == true)
        {
            if (ability.useable(user, Vector3.left, Map))
                return true;
        }
        if (foeHere(location + Vector3.right) == true)
        {
            if (ability.useable(user, Vector3.right, Map))
                return true;
        }
        return false;
    }
    public string lordName()
    {
        for (int i = 0; i< units.Count; i++)
        {
            if (units[i].lord == true)
                return units[i].name;

        }
        return "Deceased";
    }

    //clearing the movement colours
    public void clear()
    {
        Map.cleanTiles();
    }
    public abstract void setup();
    public abstract void dropMenu(unit person);
}
