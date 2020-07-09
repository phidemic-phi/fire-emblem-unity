using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatmed : MonoBehaviour
{

    public void cambatTaker(unit attacker, tile attack, unit defender, tile defend)
    {

    }



    public int random()
    {
        return Random.Range(0, 99);
    }
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
    public int crit(unit attacker, unit defender)
    {
        int temp = attacker.crit - defender.dodge;
        if (temp < 0)
            return 0;
        else
            return temp;

    }
    public int combatscore(unit attacker, unit defender)
    {
        return (accuracy(attacker, defender) * damage(attacker, defender));
    }
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
