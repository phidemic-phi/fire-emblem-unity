﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * thing that holds all the tiles and is the thing that handles all the visual things on the map
 */
public class map : MonoBehaviour
{
    // Start is called before the first frame update
    public List<List<tile>> tiles = new List<List<tile>>();

    public unit selected;

    public tile child;
    public int X;
    public int Y;
    public Affinity affinity;
    public HUD menu;

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("HUD").GetComponent(typeof(HUD)) as HUD; ;
        Vector3 location;
        float Max_x = 0;
        float Max_y = 0;

        //get the size of the map in x and z zordinates
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            child = gameObject.transform.GetChild(i).gameObject.GetComponent(typeof(tile)) as tile;
            location = child.transform.position;

            if (location[0] > Max_x)
            {
                Max_x = location[0];
            }
            if (location[2] > Max_y)
            {
                Max_y = location[2];
            }
        }
        X = (int)Max_x;
        Y = (int)Max_y;



        // puts them in a 2d list in order of position with tiles [x][z] with x and z being locration
        // done like with this long thing as children could be in any order so need to sort that first
        for (int x = 0; x <= X; x++)
        {
            List<tile> temp = new List<tile>();

            for (int y = 0; y <= Y; y++)
            {

                for (int i = 0; i < this.gameObject.transform.childCount; i++)
                {

                    child = gameObject.transform.GetChild(i).gameObject.GetComponent(typeof(tile)) as tile;
                    location = child.transform.position;

                    if (location[0] == x)
                    {

                        if (location[2] == y)
                        {
                            temp.Add(child);
                            i = this.gameObject.transform.childCount;
                        }
                    }
                }
            }
            tiles.Add(temp);


        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //found out about triple / here ... migth go back and add it, emacs never had this for c++........
    /// <summary>
    /// what do I do when a unit is clicked
    /// clear all markings
    /// makes new marking for the unit
    /// </summary>
    /// <param name="guy">is the unit selected</param>
    public void unitClicked(unit guy)
    {
        cleanTiles();
        selected = guy;
        Vector3 location = guy.transform.position;
        
        recursive((int)location[0], (int)location[2], guy.movetype, guy.move + 1);
        tiles[(int)location[0]][(int)location[2]].clear();
        makeRed((int)location[0], (int)location[2], 0);


    }

    /// <summary>
    /// a recursive function to paint tiles blue by going up, down,left, then right
    /// will not go into tiles that have a lower value or equal to the value it would put in 
    /// </summary>
    /// <param name="x">X is the x location of the unit</param>
    /// <param name="y">the Y location of the selected unit</param>
    /// <param name="type">what movement type the unit is</param>
    /// <param name="move">how much movement does the unit have</param>
    public void recursive(int x, int y, MoveType type, int move)
    {
       
        tiles[x][y].value = move;
        if (x != X)
        {
            if (tiles[x + 1][y].value < (move - tiles[x + 1][y].cost(type)))
                if(!foeHere(tiles[x + 1][y]))
                     recursive(x + 1, y, type, move - tiles[x + 1][y].cost(type));
        }
        if (x != 0)
        {
            if (tiles[x - 1][y].value < (move - tiles[x - 1][y].cost(type)))
                if (!foeHere(tiles[x - 1][y]))
                    recursive(x - 1, y, type, move - tiles[x - 1][y].cost(type));

        }



        if (y != Y)
        {
            if (tiles[x][y + 1].value < (move - tiles[x][y + 1].cost(type)))
                if (!foeHere(tiles[x][y + 1]))
                    recursive(x, y + 1, type, move - tiles[x][y + 1].cost(type));
        }
        if (y != 0)
        {
            if (tiles[x][y - 1].value < (move - tiles[x][y - 1].cost(type)))
                if (!foeHere(tiles[x][y - 1]))
                    recursive(x, y - 1, type, move - tiles[x][y - 1].cost(type));

        }
        if (allyHere(tiles[x][y]) == true)
            tiles[x][y].set_green();
        else
        {
            tiles[x][y].set_blue();
            makeRed(x,y,0);
        }
        return;
    }
    /// <summary>
    /// adds the red tiles to know where you can attack
    /// recursive calls this for every tile 
    /// only called on tiles you can get into
    /// </summary>
    /// <param name="x">x location for the tile we are at</param>
    /// <param name="y">y location for the tile we are at</param>
    /// <param name="distance">how far we are from the unit/where the unit could be</param>
    public void makeRed(int x, int y, int distance)
    {
        distance += 1;
        if (distance <= selected.max_range) {
            if (x != X)
            {
                if (tiles[x + 1][y].value == 0) {
                    if (distance >= selected.min_range)
                        tiles[x + 1][y].set_red();
                    makeRed(x + 1, y, distance );

                }
            }
            if (x != 0)
            {
                if (tiles[x - 1][y].value == 0)
                {
                    if (distance >= selected.min_range)
                        tiles[x - 1][y].set_red();
                    makeRed(x - 1, y, distance );

                }
            }



            if (y != Y)
            {
                if (tiles[x][y + 1].value == 0) { 

                    if (distance >= selected.min_range)
                        tiles[x][y+1].set_red();
                    makeRed(x , y+1, distance);

                }
            }
            if (y != 0)
            {
                if (tiles[x][y - 1].value == 0) {
                    if (distance >= selected.min_range)
                         tiles[x][y - 1].set_red();
                     makeRed(x, y - 1, distance );



                }
            }
        }
    }

    /// <summary>
    /// is there a for here, for the unit selected
    /// </summary>
    /// <param name="spot">a tile that we get the location from</param>
    /// <returns></returns>
    public bool foeHere(tile spot)
    {
        
        return selected.foeHere(spot.transform.position);
    }

    /// <summary>
    /// is there an ally of the current selected unit here
    /// </summary>
    /// <param name="spot">we just get the location from the tile</param>
    /// <returns></returns>
    public bool allyHere(tile spot)
    {

        return selected.allyHere(spot.transform.position);
    }

    /// <summary>
    /// what happens when a tile is clicked for movement
    /// </summary>
    /// <param name="spot">the tile that was clicked</param>
    public void tileClicked(tile spot)
    {
        if (!selected.allyHere(spot.transform.position) || ((spot.transform.position[2] ==selected.transform.position[2])&& (spot.transform.position[0] == selected.transform.position[0])))
        {
            List<Directions> temp = new List<Directions>();
            temp = pathfinder(spot);
            cleanTiles();

            selected.location(temp);
            if (selected.going.Count == 0)
            {

                selected.state = unitState.menus;
            }
        }
    }

    /// <summary>
    /// what happens when a tile was clicked for combat
    /// </summary>
    /// <param name="spot">the tile that was clicked</param>
    public void combatClicked(tile spot)
    {
        if (foeHere(spot))
        {
            menu.fightTile(spot);
        }
    }

    /// <summary>
    /// once we have a unit and a destination this finds the fastest path to that spot
    /// </summary>
    /// <param name="spot"> the destination</param>
    /// <returns>a list of movements to be done by the unit</returns>
    public List<Directions> pathfinder(tile spot)
    {


        List<Directions> temp = new List<Directions>();
        Vector3 location = selected.transform.position;



        while (spot.transform.position[0] != location[0] || spot.transform.position[2] != location[2])
        {

            if (spot.transform.position[0] != 0)
            {
                if (spot.value + spot.cost(selected.movetype) == tiles[(int)spot.transform.position[0] - 1][(int)spot.transform.position[2]].value)
                {
                    temp.Add(Directions.right);
                    spot = tiles[(int)spot.transform.position[0] - 1][(int)spot.transform.position[2]];
                }
            }
            if (spot.transform.position[0] != X)
            {
                if (spot.value + spot.cost(selected.movetype) == tiles[(int)spot.transform.position[0] + 1][(int)spot.transform.position[2]].value)

                {
                    temp.Add(Directions.left);
                    spot = tiles[(int)spot.transform.position[0] + 1][(int)spot.transform.position[2]];
                }
            }
            if (spot.transform.position[2] != Y)
            {
                if (spot.value + spot.cost(selected.movetype) == tiles[(int)spot.transform.position[0]][(int)spot.transform.position[2] + 1].value)
                {
                    temp.Add(Directions.down);
                    spot = tiles[(int)spot.transform.position[0]][(int)spot.transform.position[2] + 1];
                }
            }
            if (spot.transform.position[2] != 0)
            {
                if (spot.value + spot.cost(selected.movetype) == tiles[(int)spot.transform.position[0]][(int)spot.transform.position[2]- 1].value)
                {
                    temp.Add(Directions.up);
                    spot = tiles[(int)spot.transform.position[0]][(int)spot.transform.position[2] - 1];
                }
            }

            


        }

        return temp;

    }
    /// <summary>
    /// removes all changed info on the tiles
    /// </summary>
    public void cleanTiles()
    {
        for (int x = 0; x <= X; x++)
        {


            for (int y = 0; y <= Y; y++)
                tiles[x][y].clean();
        }
    }
}

