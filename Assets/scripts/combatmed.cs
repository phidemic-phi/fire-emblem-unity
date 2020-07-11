using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
combat medator is a thing that handels all the fight calculations and everything regarding dmg and healing
very basic at the moment/unworking
*/





public class combatmed : MonoBehaviour
{
    // this is the function that starts all the combat, and every other function is just a helper to this one
    public void cambatTaker(unit attacker, tile attack, unit defender, tile defend)
    {

    }


    // faster random number generation
    public int random()
    {
        return Random.Range(0, 99);
    }


    // a single round of combat
    public void attack (unit attacker, unit defender)
    {
        if(accuracy(attacker, defender) > random())
        {
            if (crit(attacker, defender) > random())
                defender.takeDamage(damage(attacker, defender) * 3);
            else
                defender.takeDamage(damage(attacker, defender));
        }
    }


    // a helper function to calculate accuracy
    public int accuracy(unit attacker, unit defender)
    {
        int boost = evasionTriangle(attacker, defender);
        int num = 0;
      
            
                num = (attacker.hit - defender.avoid) + boost;
                if (num > 100)
                    return 100;
                else
                    return num;
          
                
        
    }


    //helper function to calculate how much damage was done or can be done
    public int damage(unit attacker, unit defender)
    {
        int boost = attackTriangle(attacker, defender);
        int temp;
        if (attacker.invintory[0].damage == damageType.physical)
        {
            temp = (attacker.attack - defender.physicalDef) + boost;
            if (temp < 0)
                return 0;
            else
                return temp;
        }
        else if (attacker.invintory[0].damage == damageType.magical)
        {
            temp = (attacker.attack - defender.magicalDef) + boost;
            if (temp < 0)
                return 0;
            else
                return temp;
        }
      
            return 0;
    }


    // helper function to determine how high the crit chance is
    public int crit(unit attacker, unit defender)
    {
        int temp = attacker.crit - defender.dodge;
        if (temp < 0)
            return 0;
        else
            return temp;

    }


    // a function to give to AI to determine what to attck
    public int combatscore(unit attacker, unit defender)
    {
        return (accuracy(attacker, defender) * damage(attacker, defender));
    }


    // if triangle attack is for or against you
    public triangle advantage(unit attacker, unit defender)
    {
        if (defender.has_weapon)
        {
            Item_type temp = defender.invintory[0].type;
            switch (attacker.invintory[0].type)
            {
                case Item_type.sword:
                    if (temp == Item_type.axe)
                        return triangle.yes;
                    else if (temp == Item_type.lance)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.lance:
                    if (temp == Item_type.sword)
                        return triangle.yes;
                    else if (temp == Item_type.axe)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.axe:
                    if (temp == Item_type.lance)
                        return triangle.yes;
                    else if (temp == Item_type.sword)
                        return triangle.no;
                    else
                        return triangle.even;

                case Item_type.fire:
                    if (temp == Item_type.wind|| temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.thunder || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.wind:
                    if (temp == Item_type.thunder || temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.fire || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;
                case Item_type.thunder:
                    if (temp == Item_type.fire || temp == Item_type.light)
                        return triangle.yes;
                    else if (temp == Item_type.wind || temp == Item_type.dark)
                        return triangle.no;
                    else
                        return triangle.even;


                case Item_type.light:
                    if (temp == Item_type.dark )
                        return triangle.yes;
                    else if (temp == Item_type.wind || temp == Item_type.thunder || temp == Item_type.fire)
                        return triangle.no;
                    else
                        return triangle.even;

                case Item_type.dark:
                    if (temp == Item_type.wind || temp == Item_type.thunder || temp == Item_type.fire)
                            return triangle.yes; 
                    else if (temp == Item_type.light)
                        return triangle.yes;
                    else
                        return triangle.even;

                default:
                    return triangle.even;
            }
        }
        else
            return triangle.even;
    }

    // the accuracy boost/punishment for having the triangle
    public int evasionTriangle(unit attacker, unit defender)
    {
        triangle temp = advantage(attacker, defender);
        switch (temp)
        {
            case triangle.yes:
                return 10;
            case triangle.no:
                return -10;
            case triangle.even:
                return 0;
        }
        return 0;
        
    }

    // the damage boost/punishment for having the triangle
    public int attackTriangle(unit attacker, unit defender)
    {
        triangle temp = advantage(attacker, defender);
        switch (temp)
        {
            case triangle.yes:
                return 1;
            case triangle.no:
                return -1;
            case triangle.even:
                return 0;
        }
        return 0;
    }
}
