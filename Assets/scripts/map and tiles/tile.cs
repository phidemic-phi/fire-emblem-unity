using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class tile : MonoBehaviour
{

    public int def;
    public int res;
    public int avo;
    public int value;

    public int foot;
    public int armour;
    public int mage;
    public int knight;
    public int fly;
    public int theif;
    public int footbeast;
    public int beast;
    public int footdragon;
    public int dragon;
    public int rafel;


    public float red;
    public float blue;
    public float green;

    public Color colour;
    public Renderer cubeRenderer;
    private map mum;
    public bool fight;


    private void Start()
    {
        mum=  GetComponentInParent(typeof(map)) as map;
        setValue();
        fight = false;
    }


    // Update is called once per frame
    public void Update()
    {
    }

    public void set_blue()
    {
        colour.r = red;
        colour.g = green;
        colour.b = blue + 0.7f;
        cubeRenderer.material.color = colour;


    }
    public void set_green()
    {
        colour.r = red;
        colour.g = green + 0.7f;
        colour.b = blue ;
        cubeRenderer.material.color = colour;


    }
    public void set_red()
    {
        colour.r = red + 0.7f;
        colour.g = green;
        colour.b = blue;
        cubeRenderer.material.color = colour;

        fight = true;
    }

    public int cost(MoveType type)
    {
        switch (type)
        {
            case MoveType.foot:
                return foot;
            case MoveType.armour:
                return armour;
            case MoveType.mage:
                return mage;
            case MoveType.knight:
                return knight;
            case MoveType.flyer:
                return fly;
            case MoveType.theif:
                return theif;
            case MoveType.footbeast:
                return footbeast;
            case MoveType.beast:
                return beast;
            case MoveType.footdragon:
                return footdragon;
            case MoveType.dragon:
                return dragon;
            case MoveType.rafel:
                return rafel;
            default:
                return 999;
        }

               
    }
    void OnMouseDown()
    {
        if (value > 0)
        {
            mum.tileClicked(this);
        }
        else if (fight == true)
            mum.combatClicked(this);

    }
    public void clean()
    {
        clear();
        value = 0;
        fight = false;
    }
    public void clear()
    {
        colour.r = red;
        colour.g = green;
        colour.b = blue;
        cubeRenderer.material.color = colour;
    }
    public abstract void getInfo(string name);
    public abstract void setValue();
    
}
