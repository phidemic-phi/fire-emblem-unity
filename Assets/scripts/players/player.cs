using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class player : MonoBehaviour
{

    
    public bool turn;
    public List<unit> units = new List<unit>();
    public map Map;
    public List<player> foes = new List<player>();
    public List<player> allys = new List<player>();
    private game_controller god;
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            units.Add(gameObject.transform.GetChild(i).gameObject.GetComponent(typeof(unit)) as unit);
         
        }
        Map = GameObject.FindGameObjectWithTag("map").GetComponent(typeof(map)) as map;
        god = GetComponentInParent(typeof(game_controller)) as game_controller;
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD;
      
        setup();
    }
   

    public bool unitClicked(unit guy)
    {
        if (turn == true)
        {
          
            hud.getunit(guy);
            Map.unitClicked(guy);
            return true;
        }
        return false;
    }

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

    public unit getFoe(Vector3 location)
    {
       
        for (int i = 0; i < foes.Count; i++)
        {
            if (foes[i].isHere(location))
                return foes[i].getHere(location);
        }
        return null;
    }

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


    public void moveDone()
    {
        clear();
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
    public void clear()
    {
        Map.cleanTiles();
    }
    public abstract void setup();
}
