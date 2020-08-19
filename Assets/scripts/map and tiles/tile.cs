using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//what the ground is made out of
public abstract class tile : MonoBehaviour
{
    // statsthat units get from being in it
    public int def;
    public int res;
    public int avo;
    public int value;

    // cost of going into the tile from those classes
    //stored as varibles as might make spells that can change the values, as I want to do some unique things
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

    public bool waitable = true;
    private map mum;
    public bool fight;
    public tileState state;

    private void Start()
    {
        state = tileState.clear;
        mum=  GetComponentInParent(typeof(map)) as map;
        setValue();
        fight = false;
    }


    // Update is called once per frame
    public void Update()
    {
    }
    // changing the colour for certain things
    public void set_blue()
    {
        if (state != tileState.blue)
        {
            if (transform.childCount > 0)
            {
                for (int i = transform.childCount; i > 0; i--)
                {
                    Destroy(transform.GetChild(i - 1).gameObject, 0f);
                }
            }
            Vector3 pos = transform.position;
            pos[1] += 0.25f;
            Instantiate(mum.blueSquare, pos, Quaternion.identity, transform);
            state = tileState.blue;
        }

    }
    public void set_green()
    {
        if (state != tileState.green)
        {
            if (transform.childCount > 0)
            {
                for (int i = transform.childCount; i > 0; i--)
                {
                    Destroy(transform.GetChild(i - 1).gameObject, 0f);
                }
            }
            Vector3 pos = transform.position;
            pos[1] += 0.25f;
            Instantiate(mum.greenSquare, pos, Quaternion.identity, transform);
            state = tileState.green;

        }
    }
    public void set_red()
    {
        if (state == tileState.clear)
        {
            Vector3 pos = transform.position;
            pos[1] += 0.25f;
            Instantiate(mum.redSquare, pos, Quaternion.identity, transform);
            state = tileState.red;
        }
        fight = true;
      
    }

    // getting the cost out of it
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

    //what happens when clicked on
    public void clicked()
    {
        if (value > 0)
        {
            mum.tileClicked(this);
        }
        else if (fight == true)
            mum.combatClicked(this);

    }
    //what happens when clicked on
    void OnMouseDown()
    {
        clicked();

    }

    //removing all movement from unit changes
    public void clean()
    {
        
        clear();
        value = 0;
        fight = false;
    }

    // just removes the colours not the other things
    public void clear()
    {
        if (transform.childCount > 0)
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                Destroy(transform.GetChild(i - 1).gameObject, 0f);
            }
        }
        state = tileState.clear;
    }
    public abstract void getInfo(string name);
    public abstract void setValue();
    
}
